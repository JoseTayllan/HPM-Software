using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPM_Software
{
    public partial class Form1 : Form
    {
        private Funcoes funcoes;
        private CancellationTokenSource cancellationTokenSource;
        private readonly string pdfFolderPath;
        private GoogleSheatsManager manager;

        public Form1()
        {
            InitializeComponent();
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pdfFolderPath = Path.Combine(documentsPath, "PDFs");
            Directory.CreateDirectory(pdfFolderPath);

            UserCredential credential = GoogleAuthentication.Login(Program.GoogleClientId, Program.GoogleSecret, new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets });
            manager = new GoogleSheatsManager(credential);
            funcoes = new Funcoes(manager, string.Empty, "Sheet1");
            cancellationTokenSource = new CancellationTokenSource();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxGoogleClientId.Text = Program.GoogleClientId;
            textBoxGoogleSecret.Text = Program.GoogleSecret;
        }

        private async void btnExtrair_Click(object sender, EventArgs e)
        {
            btnExtrair.Enabled = false;

            try
            {
                // Inicia a extração em segundo plano usando Task.Run
                await Task.Run(() => LerEPreencherPlanilhaContinuamente(cancellationTokenSource.Token), cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                // Captura a exceção caso a operação seja cancelada
                // Isso pode acontecer quando a aplicação é fechada
            }
            finally
            {
                // Habilita o botão novamente quando a extração terminar
                btnExtrair.Enabled = true;
            }
        }

        private async Task LerEPreencherPlanilhaContinuamente(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string[] pdfFiles = Directory.GetFiles(pdfFolderPath, "*.pdf");

                foreach (string pdfFile in pdfFiles)
                {
                    try
                    {
                        await funcoes.LerEEnviarDadosDoPDFAsync(pdfFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar o arquivo PDF '{pdfFile}': {ex.Message}");
                    }
                }

                // Aguarda antes de verificar novamente a pasta de PDFs
                await Task.Delay(5000, cancellationToken); // Aguarda 5 segundos entre cada verificação
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Cancela a tarefa e libera os recursos ao fechar o formulário
            cancellationTokenSource.Cancel();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Program.GoogleClientId = textBoxGoogleClientId.Text;
            Program.GoogleSecret = textBoxGoogleSecret.Text;

            var config = new Program.Config
            {
                GoogleClientId = Program.GoogleClientId,
                GoogleSecret = Program.GoogleSecret
            };

            string configFilePath = "config.json";

            try
            {
                File.WriteAllText(configFilePath, JsonConvert.SerializeObject(config, Formatting.Indented));
                MessageBox.Show("Client ID e Secret foram atualizados e salvos!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configuração: {ex.Message}");
            }
        }

        private void textBoxGoogleClientId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxGoogleSecret_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
