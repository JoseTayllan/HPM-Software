using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPM_Software
{
    public interface IGoogleSheeatsManager
    {
        Spreadsheet CreateNew(string documentName);
        Task AddDataAsync(string spreadsheetId, string sheetName, IList<IList<object>> values);
        bool CheckSpreadsheetExists(string spreadsheetId);
        string GetSheetName(string spreadsheetId);
    }
}
