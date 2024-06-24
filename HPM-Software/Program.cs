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
        private const string PlanilhaIdFilePath = "planilha_id.txt";
        private const string PDFFolderPath = @"C:\Users\Neymar Jr\OneDrive\Documentos\PDFs";

        public static string GoogleClientId { get; set; }
        public static string GoogleSecret { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static async Task Main(string[] args)
        {
            LoadConfig();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            try
            {
                // Inicialização e autenticação
                UserCredential credential = GoogleAuthentication.Login(GoogleClientId, GoogleSecret, new[] { Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets });
                GoogleSheatsManager manager = new GoogleSheatsManager(credential);

                // Carregar ou criar uma nova planilha
                string spreadsheetId = LoadOrCreateSpreadsheet(manager);

                // Obter o nome da primeira aba da planilha
                string sheetName = manager.GetSheetName(spreadsheetId);

                // Monitorar a pasta de PDFs continuamente
                await MonitorarPastaDePDFsAsync(manager, spreadsheetId, sheetName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private static void LoadConfig()
        {
            try
            {
                var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                GoogleClientId = config.GoogleClientId;
                GoogleSecret = config.GoogleSecret;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar configuração: {ex.Message}");
            }
        }

        private static string LoadOrCreateSpreadsheet(GoogleSheatsManager manager)
        {
            string spreadsheetId = LoadSpreadsheetId();

            if (string.IsNullOrEmpty(spreadsheetId) || !manager.CheckSpreadsheetExists(spreadsheetId))
            {
                // Cria uma nova planilha se o ID não estiver armazenado ou se a planilha não existir mais
                var newSheet = manager.CreateNew(PlanilhaNome);
                spreadsheetId = newSheet.SpreadsheetId;
                SaveSpreadsheetId(spreadsheetId);
            }

            return spreadsheetId;
        }

        private static string LoadSpreadsheetId()
        {
            if (File.Exists(PlanilhaIdFilePath))
            {
                return File.ReadAllText(PlanilhaIdFilePath).Trim();
            }
            return null;
        }

        private static void SaveSpreadsheetId(string spreadsheetId)
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
                        // Instanciar Funcoes e processar o PDF
                        Funcoes funcoes = new Funcoes(manager, spreadsheetId, sheetName);
                        await funcoes.LerEEnviarDadosDoPDFAsync(pdfPath);

                        // Mover ou excluir o PDF após o processamento, se necessário
                        // Exemplo: File.Move(pdfPath, Path.Combine(doneFolder, Path.GetFileName(pdfPath)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar o PDF '{pdfPath}': {ex.Message}");
                    }
                }

                await Task.Delay(5000); // Aguarda 5 segundos antes de verificar novamente a pasta
            }
        }

        public class Config
        {
            public string GoogleClientId { get; set; }
            public string GoogleSecret { get; set; }
        }
    }
}
