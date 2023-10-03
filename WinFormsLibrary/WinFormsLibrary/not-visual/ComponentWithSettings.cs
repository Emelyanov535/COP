using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.ComponentModel;

namespace WinFormsLibrary.not_visual
{
    public partial class ComponentWithSettings : Component
    {
        public ComponentWithSettings()
        {
            InitializeComponent();
        }

        public ComponentWithSettings(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GenerateTableDocument(string filePath, string documentTitle, List<string> columnHeaderNames, List<string> rowHeaderNames, List<List<object>> tableData)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(documentTitle) || columnHeaderNames == null || rowHeaderNames == null || tableData == null)
            {
                throw new ArgumentNullException("Один или несколько параметров отсутсвуют.");
            }

            if (columnHeaderNames.Count != tableData[0].Count || rowHeaderNames.Count != tableData.Count)
            {
                throw new ArgumentException("Несоответствие между количеством заголовков и данных.");
            }

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Документ");

            IRow titleRow = sheet.CreateRow(0);
            titleRow.CreateCell(0).SetCellValue(documentTitle);

            IRow headerRow = sheet.CreateRow(1);
            for (int i = 0; i < columnHeaderNames.Count; i++)
            {
                headerRow.CreateCell(i + 1).SetCellValue(columnHeaderNames[i]);
            }

            for (int rowIndex = 0; rowIndex < tableData.Count; rowIndex++)
            {
                IRow dataRow = sheet.CreateRow(rowIndex + 2);
                dataRow.CreateCell(0).SetCellValue(rowHeaderNames[rowIndex]);

                for (int colIndex = 0; colIndex < columnHeaderNames.Count; colIndex++)
                {
                    dataRow.CreateCell(colIndex + 1).SetCellValue(tableData[rowIndex][colIndex].ToString());
                }
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileStream);
            }
        }
    }
}
