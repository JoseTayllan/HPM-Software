using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPM_Software
{
    public class GoogleSheatsManager : IGoogleSheeatsManager
    {
        private readonly SheetsService _sheetsService;

        public GoogleSheatsManager(UserCredential credential)
        {
            _sheetsService = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Sheets API"
            });
        }

        public Spreadsheet CreateNew(string documentName)
        {
            if (string.IsNullOrEmpty(documentName))
                throw new ArgumentNullException(nameof(documentName));

            var sheetTitle = "Dados";

            var documentCreateRequest = _sheetsService.Spreadsheets.Create(new Spreadsheet()
            {
                Sheets = new List<Sheet>()
                {
                    new Sheet()
                    {
                        Properties = new SheetProperties()
                        {
                            Title = sheetTitle,
                        }
                    }
                },
                Properties = new SpreadsheetProperties()
                {
                    Title = documentName
                }
            });

            var spreadsheet = documentCreateRequest.Execute();
            spreadsheet.Sheets[0].Properties.Title = sheetTitle;
            return spreadsheet;
        }


        public async Task AddDataAsync(string spreadsheetId, string sheetName, IList<IList<object>> values)
        {
            var range = $"{sheetName}!A1";
            var valueRange = new ValueRange
            {
                Values = values
            };

            try
            {
                var appendRequest = _sheetsService.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.RAW;
                await appendRequest.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar dados à planilha: {ex.Message}");
                throw new Exception($"Erro ao adicionar dados à planilha: {ex.Message}", ex); // Re-lança a exceção com uma mensagem personalizada
            }
        }

        public bool CheckSpreadsheetExists(string spreadsheetId)
        {
            try
            {
                var spreadsheet = _sheetsService.Spreadsheets.Get(spreadsheetId).Execute();
                return spreadsheet != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar a existência da planilha: {ex.Message}");
                return false;
            }
        }

        public string GetSheetName(string spreadsheetId)
        {
            try
            {
                var spreadsheet = _sheetsService.Spreadsheets.Get(spreadsheetId).Execute();
                return spreadsheet.Sheets[0].Properties.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter o nome da planilha: {ex.Message}");
                return null;
            }
        }
        public async Task CriarAbaAsync(string spreadsheetId, string novaAbaNome)
        {
            var addSheetRequest = new AddSheetRequest
            {
                Properties = new SheetProperties
                {
                    Title = novaAbaNome
                }
            };

            var request = new Request { AddSheet = addSheetRequest };
            var batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest
            {
                Requests = new List<Request> { request }
            };

            try
            {
                var batchUpdateRequest = _sheetsService.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, spreadsheetId);
                await batchUpdateRequest.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar nova aba: {ex.Message}");
                throw new Exception($"Erro ao criar nova aba: {ex.Message}", ex); // Re-lança a exceção com uma mensagem personalizada
            }
        }
    }
}
