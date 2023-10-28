using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.ComponentModel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace WinFormsLibrary.not_visual
{
    public partial class Gistograma : Component
    {
        public Gistograma()
        {
            InitializeComponent();
        }

        public Gistograma(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void GenerateExcelChartDocument(string filePath, string documentTitle, string chartTitle, LegendPosition legendPosition, List<ChartData> dataSeries)
        {
            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(documentTitle) || dataSeries == null || dataSeries.Count == 0)
            {
                throw new ArgumentException("Invalid input data");
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fileInfo = new FileInfo(filePath);
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(documentTitle);

                int rowStart = 1;
                int columnStart = 2;

                var chart = worksheet.Drawings.AddChart(chartTitle, eChartType.ColumnClustered);
                chart.SetPosition(1, 0, 1, 0);
                chart.SetSize(800, 400);
                chart.Title.Text = chartTitle;

                switch (legendPosition)
                {
                    case LegendPosition.Top:
                        chart.Legend.Position = eLegendPosition.Top;
                        break;
                    case LegendPosition.Right:
                        chart.Legend.Position = eLegendPosition.Right;
                        break;
                    case LegendPosition.Bottom:
                        chart.Legend.Position = eLegendPosition.Bottom;
                        break;
                    case LegendPosition.Left:
                        chart.Legend.Position = eLegendPosition.Left;
                        break;
                }

                for (int i = 0; i < dataSeries.Count; i++)
                {
                    var data = dataSeries[i].Data;
                    var dataRange = worksheet.Cells[rowStart + 1, columnStart + i, rowStart + data.Length, columnStart + i];
                    dataRange.LoadFromCollection(data);
                    var series = chart.Series.Add(dataRange, worksheet.Cells[rowStart + 1, 1, rowStart + data.Length, 1]);
                    series.Header = dataSeries[i].SeriesName;
                }
                package.Save();
            }
        }
    }
}
