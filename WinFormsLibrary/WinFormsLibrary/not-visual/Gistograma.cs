

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.UserModel.Charts;
using NPOI.SS.Util;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
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

        public void GenerateChartDocument(
            string filePath,
            string documentTitle,
            string chartTitle,
            LegendPosition legendPosition,
            List<ChartData> chartDataList)
        {
            // Проверка на заполненность входных данных
            if (string.IsNullOrEmpty(filePath) ||
                string.IsNullOrEmpty(documentTitle) ||
                string.IsNullOrEmpty(chartTitle) ||
                chartDataList == null || chartDataList.Count == 0)
            {
                throw new ArgumentException("Все входные данные должны быть заполнены.");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Создаем новый пакет Excel
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("Гистограмма");

                // Добавляем заголовок документа
                worksheet.Cells["A1"].Value = documentTitle;

                // Добавляем заголовок для гистограммы
                worksheet.Cells["A3"].Value = chartTitle;

                // Добавляем данные для гистограммы
                var startCell = worksheet.Cells["A5"];
                var endCell = worksheet.Cells["B5"].Offset(chartDataList.Count, 1);
                var chartDataSeries = worksheet.Cells[startCell.Address + ":" + endCell.Address];
                chartDataSeries.LoadFromCollection(
                    chartDataList.Select(c => new { c.SeriesName, c.DataPoints }), true);

                // Создаем гистограмму
                var chart = worksheet.Drawings.AddChart("Гистограмма", eChartType.ColumnClustered);
                chart.SetPosition(6, 0, 1, 0);
                chart.SetSize(600, 400);
                chart.Title.Text = chartTitle;

                // Устанавливаем расположение легенды
                // Устанавливаем расположение легенды
                chart.Legend.Position = (eLegendPosition)legendPosition; // Замените на нужное значение


                // Устанавливаем источник данных для гистограммы
                var dataRange = chartDataSeries.Offset(1, 0, chartDataList.Count, 1);
                var categoriesRange = chartDataSeries.Offset(0, 1, chartDataList.Count, 1);
                var chartSeries = chart.Series.Add(dataRange, categoriesRange);
                chartSeries.Header = chartDataList[0].SeriesName;

                // Сохраняем Excel-файл
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}
