using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.ComponentModel;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

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

        public void GenerateExcelDocument<T>(string filePath, string documentTitle, List<ColumnConfig> columnConfigs, float headerHeight, float rowHeight, List<T> data)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(documentTitle) || columnConfigs == null || columnConfigs.Count == 0 || data == null || data.Count == 0)
            {
                throw new ArgumentException("Invalid input data.");
            }

            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Документ 2");

            IRow titleRow = sheet.CreateRow(0);
            ICell titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(documentTitle);
            var titleCellStyle = workbook.CreateCellStyle();
            var titleFont = workbook.CreateFont();
            titleFont.FontHeightInPoints = 20;
            titleFont.IsBold = true;
            titleCellStyle.SetFont(titleFont);
            titleCell.CellStyle = titleCellStyle;

            IRow headerRow = sheet.CreateRow(1);
            for (int i = 0; i < columnConfigs.Count; i++)
            {
                ICell headerCell = headerRow.CreateCell(i);
                headerCell.SetCellValue(columnConfigs[i].PropertyName);
                sheet.SetColumnWidth(i, (int)(columnConfigs[i].Width * 256));
                headerRow.HeightInPoints = headerHeight;
                titleFont.FontHeightInPoints = 20;
                titleFont.IsBold = true;
                titleCellStyle.SetFont(titleFont);
                headerCell.CellStyle = titleCellStyle;
            }

            var firstColumnCellStyle = workbook.CreateCellStyle();
            var firstColumnFont = workbook.CreateFont();
            firstColumnFont.FontHeightInPoints = 20;
            firstColumnFont.IsBold = true;
            firstColumnCellStyle.SetFont(firstColumnFont);

            for (int i = 0; i < data.Count; i++)
            {
                IRow dataRow = sheet.CreateRow(i + 2);
                for (int j = 0; j < columnConfigs.Count; j++)
                {
                    var property = typeof(T).GetProperty(columnConfigs[j].PropertyName);
                    if (property != null)
                    {
                        ICell dataCell = dataRow.CreateCell(j);
                        dataCell.SetCellValue(property.GetValue(data[i]).ToString());
                        dataRow.HeightInPoints = rowHeight;
 
                        if (j == 0)
                        {
                            dataCell.CellStyle = firstColumnCellStyle;
                        }
                    }
                }
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileStream);
            }
        }
    }
}
