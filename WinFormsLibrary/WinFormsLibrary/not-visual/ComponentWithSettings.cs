using NPOI.SS.Formula.Functions;
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

        public void GenerateExcelDocument<T>(string filePath, string documentTitle, List<ColumnConfig> columnConfigs, float headerHeight, float rowHeight, List<T> data)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(documentTitle) || columnConfigs == null || columnConfigs.Count == 0 || data == null || data.Count == 0)
            {
                throw new ArgumentException("Invalid input data.");
            }

            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Документ");

            IRow titleRow = sheet.CreateRow(0);
            ICell titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(documentTitle);

            IRow headerRow = sheet.CreateRow(1);
            for (int i = 0; i < columnConfigs.Count; i++)
            {
                ICell headerCell = headerRow.CreateCell(i);
                headerCell.SetCellValue(columnConfigs[i].PropertyName);
                sheet.SetColumnWidth(i, (int)(columnConfigs[i].Width * 256));
                headerRow.HeightInPoints = headerHeight;
            }

            // Add data
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
