using NPOI.SS.Util;
using System.ComponentModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;

namespace WinFormsLibrary
{
    public partial class CustomComponentForXlsTable : Component
    {
        public CustomComponentForXlsTable()
        {
            InitializeComponent();
        }

        public CustomComponentForXlsTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GenerateExcelDocument(string filePath, string documentTitle, List<string[,]> tablesList)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(filePath));

            if (string.IsNullOrWhiteSpace(documentTitle))
                throw new ArgumentException("Заголовок документа не может быть пустым", nameof(documentTitle));

            if (tablesList == null || tablesList.Count == 0)
                throw new ArgumentException("Список таблиц не может быть пустым", nameof(tablesList));

            // Создаем новую книгу Excel
            var workbook = new XSSFWorkbook();

            // Устанавливаем заголовок документа
            var titleRow = workbook.CreateSheet("Документ").CreateRow(0);
            var titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(documentTitle);

            var titleCellStyle = workbook.CreateCellStyle();
            var titleFont = workbook.CreateFont();
            titleFont.FontHeightInPoints = 9;
            titleFont.IsBold = true;
            titleCellStyle.SetFont(titleFont);
            titleCellStyle.Alignment = HorizontalAlignment.Center;
            titleCell.CellStyle = titleCellStyle;

            int currentRow = 1;

            foreach (var table in tablesList)
            {
                if (table == null || table.Length == 0)
                    continue;

                int rowCount = table.GetLength(0);
                int columnCount = table.GetLength(1);

                for (int i = 0; i < rowCount; i++)
                {
                    var dataRow = workbook.GetSheetAt(0).CreateRow(currentRow + i);

                    for (int j = 0; j < columnCount; j++)
                    {
                        var cell = dataRow.CreateCell(j);
                        cell.SetCellValue(table[i, j]);

                        // Устанавливаем границы ячеек
                        var cellStyle = workbook.CreateCellStyle();
                        cellStyle.BorderBottom = BorderStyle.Thin;
                        cellStyle.BorderTop = BorderStyle.Thin;
                        cellStyle.BorderLeft = BorderStyle.Thin;
                        cellStyle.BorderRight = BorderStyle.Thin;
                        cell.CellStyle = cellStyle;
                    }
                }

                // Устанавливаем границы для всей таблицы
                var tableRegion = new CellRangeAddress(currentRow, currentRow + rowCount - 1, 0, columnCount - 1);
                RegionUtil.SetBorderBottom((int)BorderStyle.Thin, tableRegion, workbook.GetSheetAt(0));
                RegionUtil.SetBorderTop((int)BorderStyle.Thin, tableRegion, workbook.GetSheetAt(0));
                RegionUtil.SetBorderLeft((int)BorderStyle.Thin, tableRegion, workbook.GetSheetAt(0));
                RegionUtil.SetBorderRight((int)BorderStyle.Thin, tableRegion, workbook.GetSheetAt(0));

                currentRow += rowCount + 1; // Пустая строка между таблицами
            }

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fs);
            }
        }
    }
}
