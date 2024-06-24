using Google.Apis.Sheets.v4.Data;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HPM_Software
{
    public class Funcoes
    {
        private readonly string pdfFolderPath;
        private readonly GoogleSheatsManager _googleSheetsManager;
        private readonly string _spreadsheetId;
        private readonly string _sheetName;
        private readonly Dictionary<string, List<string>> pdfTexts;

        public Funcoes(GoogleSheatsManager googleSheetsManager, string spreadsheetId, string sheetName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pdfFolderPath = Path.Combine(documentsPath, "PDFs");
            Directory.CreateDirectory(pdfFolderPath);

            _googleSheetsManager = googleSheetsManager;
            _spreadsheetId = spreadsheetId;
            _sheetName = sheetName;

            pdfTexts = new Dictionary<string, List<string>>();
        }

        public async Task LerEEnviarDadosDoPDFAsync(string pdfPath)
        {
            try
            {
                using (PdfReader pdfReader = new PdfReader(pdfPath))
                using (PdfDocument pdfDoc = new PdfDocument(pdfReader))
                {
                    int numberOfPages = pdfDoc.GetNumberOfPages();
                    List<string> pagesText = new List<string>();

                    for (int i = 1; i <= numberOfPages; i++)
                    {
                        string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                        pagesText.Add(text);
                    }

                    pdfTexts[pdfPath] = pagesText;
                }

                await ExtrairDadosClientesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler o arquivo PDF '{pdfPath}': {ex.Message}", ex);
            }
        }

        private async Task ExtrairDadosClientesAsync()
        {
            List<IList<object>> values = new List<IList<object>>();

            Regex nomeClientePattern = new Regex(@"Nome\s+do\s+Cliente:\s*(.*)", RegexOptions.Compiled);
            Regex clientePattern = new Regex(@"Cliente:\s*(.*?)\s*Telefone:", RegexOptions.Compiled | RegexOptions.Singleline);
            Regex emissaoPattern = new Regex(@"Emissão:\s*(\d{2}/\d{2}/\d{4})\s+(\d{2}:\d{2}:\d{2})", RegexOptions.Compiled);
            Regex profissionalPattern = new Regex(@"Profissional:\s*(.*?)\s+-\s+Conselho:", RegexOptions.Compiled | RegexOptions.Singleline);
            Regex guiaPattern = new Regex(@"Guia:\s*(\d{3}-\d{6}\.\d-\d)", RegexOptions.Compiled);
            Regex totalPattern = new Regex(@"Total:\s*(\d{1,3}(?:\.\d{3})*(?:,\d{2})?)", RegexOptions.Compiled);

            foreach (var kvp in pdfTexts)
            {
                string pdfPath = kvp.Key;
                List<string> pagesText = kvp.Value;

                foreach (string text in pagesText)
                {
                    string nomeCliente = null;
                    string dataEmissao = null;
                    string horarioEmissao = null;
                    string nomeProfissional = null;
                    string numeroGuia = null;
                    string valorTotal = null;

                    // Tenta encontrar "Nome do Cliente:"
                    Match nomeClienteMatch = nomeClientePattern.Match(text);
                    if (nomeClienteMatch.Success)
                    {
                        nomeCliente = nomeClienteMatch.Groups[1].Value.Trim();
                    }
                    else
                    {
                        //Tenta encontrar "Cliente:" seguido de "Telefone:"
                        Match clienteMatch = clientePattern.Match(text);
                        if (clienteMatch.Success)
                        {
                            nomeCliente = clienteMatch.Groups[1].Value.Trim();
                        }
                    }

                    // Procura a data e o horário de emissão
                    Match emissaoMatch = emissaoPattern.Match(text);
                    if (emissaoMatch.Success)
                    {
                        dataEmissao = emissaoMatch.Groups[1].Value.Trim(); // Captura a data
                        horarioEmissao = emissaoMatch.Groups[2].Value.Trim(); // Captura o horário
                    }

                    // Procura o nome do profissional e o número do conselho
                    Match profissionalMatch = profissionalPattern.Match(text);
                    if (profissionalMatch.Success)
                    {
                        nomeProfissional = ExtrairPrimeiroESegundoNomes(profissionalMatch.Groups[1].Value.Trim());
                    }

                    // Procura o número da guia
                    Match guiaMatch = guiaPattern.Match(text);
                    if (guiaMatch.Success)
                    {
                        numeroGuia = guiaMatch.Groups[1].Value.Trim();
                    }

                    // Procura o valor total
                    Match totalMatch = totalPattern.Match(text);
                    if (totalMatch.Success)
                    {
                        valorTotal = totalMatch.Groups[1].Value.Trim();
                    }

                    // Se encontrar os dados necessários, adiciona à lista de valores
                    if (nomeCliente != null && dataEmissao != null && horarioEmissao != null && nomeProfissional != null && numeroGuia != null && valorTotal != null)
                    {
                        values.Add(new List<object>
                        {
                            nomeCliente,
                            dataEmissao,
                            horarioEmissao,
                            nomeProfissional,
                            numeroGuia,
                            valorTotal
                        });
                    }
                }
            }

            // Envia os dados para o Google Sheets
            try
            {
                await _googleSheetsManager.AddDataAsync(_spreadsheetId, _sheetName, values);
                Console.WriteLine("Dados extraídos e enviados para o Google Sheets.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar dados para o Google Sheets: {ex.Message}");
                throw; // Re-lança a exceção para que a camada superior trate adequadamente
            }
        }

        private string ExtrairPrimeiroESegundoNomes(string nomeCompleto)
        {
            var nomes = nomeCompleto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return nomes.Length >= 2 ? $"{nomes[0]} {nomes[1]}" : nomeCompleto;
        }

        public void ExtrairDados()
        {
            // Método reservado para futuras extrações gerais
        }
    }
}
