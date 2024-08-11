using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPM_Software
{
    internal static class Program
    {
        private const string PlanilhaNome = "Dados Extraídos PDF";
        public const string PlanilhaIdFilePath = "planilha_id.txt";
        private static string PDFFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PDFs");

        public static string GoogleClientId { get; set; }
        public static string GoogleSecret { get; set; }

        [STAThread]
        private static async Task Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            Console.WriteLine("Verificando configuração...");

            if (!LoadConfig())
            {
                Console.WriteLine("Arquivo de configuração não encontrado. Exibindo formulário de configuração.");
                ConfigForm configForm = new ConfigForm();
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    GoogleClientId = configForm.GoogleClientId;
                    GoogleSecret = configForm.GoogleSecret;
                    SaveConfig();
                }
                else
                {
                    MessageBox.Show("Configuration is required to run the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Console.WriteLine("Iniciando a aplicação principal...");
            Application.Run(new Form1());

            try
            {
                Console.WriteLine("Autenticando com o Google...");
                UserCredential credential = await GoogleAuthentication.LoginAsync(GoogleClientId, GoogleSecret, new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets });
                GoogleSheatsManager manager = new GoogleSheatsManager(credential);

                string spreadsheetId = LoadOrCreateSpreadsheet(manager);
                string sheetName = manager.GetSheetName(spreadsheetId);

                Console.WriteLine("Monitorando a pasta de PDFs...");
                await MonitorarPastaDePDFsAsync(manager, spreadsheetId, sheetName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool LoadConfig()
        {
            try
            {
                if (File.Exists("config.json"))
                {
                    var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                    GoogleClientId = config.GoogleClientId;
                    GoogleSecret = config.GoogleSecret;
                    return true;
                }
                Console.WriteLine("Arquivo de configuração não encontrado.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar configuração: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void SaveConfig()
        {
            try
            {
                var config = new Config
                {
                    GoogleClientId = GoogleClientId,
                    GoogleSecret = GoogleSecret
                };
                File.WriteAllText("config.json", JsonConvert.SerializeObject(config));
                Console.WriteLine("Configuração salva com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configuração: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string LoadOrCreateSpreadsheet(GoogleSheatsManager manager)
        {
            string spreadsheetId = LoadSpreadsheetId();

            if (string.IsNullOrEmpty(spreadsheetId) || !manager.CheckSpreadsheetExists(spreadsheetId))
            {
                var newSheet = manager.CreateNew(PlanilhaNome);
                spreadsheetId = newSheet.SpreadsheetId;
                SaveSpreadsheetId(spreadsheetId);
            }

            return spreadsheetId;
        }

        public static string LoadSpreadsheetId()
        {
            if (File.Exists(PlanilhaIdFilePath))
            {
                return File.ReadAllText(PlanilhaIdFilePath).Trim();
            }
            return null;
        }

        public static void SaveSpreadsheetId(string spreadsheetId)
        {
            File.WriteAllText(PlanilhaIdFilePath, spreadsheetId);
        }

        private static async Task MonitorarPastaDePDFsAsync(GoogleSheatsManager manager, string spreadsheetId, string sheetName)
        {
            while (true)
            {
                string[] pdfFiles = Directory.GetFiles(PDFFolderPath, "*.pdf");

                foreach (string pdfPath in pdfFiles)
                {
                    try
                    {
                        Funcoes funcoes = new Funcoes(manager, spreadsheetId, sheetName);
                        await funcoes.LerEEnviarDadosDoPDFAsync(pdfPath);

                        string doneFolder = Path.Combine(PDFFolderPath, "Processados");
                        if (!Directory.Exists(doneFolder))
                        {
                            Directory.CreateDirectory(doneFolder);
                        }

                        string destinationPath = Path.Combine(doneFolder, Path.GetFileName(pdfPath));
                        File.Move(pdfPath, destinationPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar o PDF '{pdfPath}': {ex.Message}");
                    }
                }

                await Task.Delay(5000);
            }
        }

        public class Config
        {
            public string GoogleClientId { get; set; }
            public string GoogleSecret { get; set; }
        }
    }
}
