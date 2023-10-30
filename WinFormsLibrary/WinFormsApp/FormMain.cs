using ComponentsLibraryNet60.DocumentWithChart;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.ViewModels;
using ControlsLibraryNet60.Data;
using ControlsLibraryNet60.Models;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsLibrary.Helpers;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        private readonly IProviderLogic _providerLogic;
        public FormMain(IProviderLogic providerLogic)
        {
            InitializeComponent();
            _providerLogic = providerLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            listBoxValues.Clear();
            try
            {
                var list = _providerLogic.ReadList(null);
                if (list != null)
                {
                    listBoxValues.SetLayoutInfo(" Идентификатор: {Id}, " +
                        "Название: {Name}, " +
                        "ФИО Менеджера: {Manager}, " +
                        "Частота поставок в год: {DeliveryFrequencyPerYear}",
                        "{",
                        "}");
                    int counter = 0;
                    foreach (var item in list)
                    {
                        listBoxValues.FillProperty(item, counter, "Manager");
                        listBoxValues.FillProperty(item, counter, "Id");
                        listBoxValues.FillProperty(item, counter, "Name");
                        listBoxValues.FillProperty(item, counter, "DeliveryFrequencyPerYear");

                        counter++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void AddProviderItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormProvider));
            if (service is FormProvider form)
            {
                form.ShowDialog();
                LoadData();
            }
        }

        private void EditProviderItem_Click(object sender, KeyEventArgs e)
        {
            if (listBoxValues.GetObjectFromStr<ProviderViewModel>() == null)
            {
                return;
            }
            else
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormProvider));
                if (service is FormProvider form)
                {
                    form.Id = Convert.ToInt32(listBoxValues.GetObjectFromStr<ProviderViewModel>()?.Id);
                    form.ShowDialog();
                    LoadData();
                }
            }
        }

        private void RemoveProviderItem_Click(object sender, EventArgs e)
        {
            if (listBoxValues.GetObjectFromStr<ProviderViewModel>() == null) return;
            if (MessageBox.Show(
                "Вы хотите удалить выбранный элементы?",
                "Вопрос",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var del = listBoxValues.GetObjectFromStr<ProviderViewModel>();
                _providerLogic.Delete(del);
                LoadData();
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        AddProviderItem_Click(sender, e);
                        break;
                    case Keys.U:
                        EditProviderItem_Click(sender, e);
                        break;
                    case Keys.D:
                        RemoveProviderItem_Click(sender, e);
                        break;
                    case Keys.S:
                        GetSimpleDocumentItem_Click(sender, e);
                        break;
                    case Keys.T:
                        GetTableDocumentItem_Click(sender, e);
                        break;
                    case Keys.C:
                        GetDiagramDocumentItem_Click(sender, e);
                        break;
                    case Keys.Q:
                        OpenListManager_Click(sender, e);
                        break;
                }
            }
        }

        private void GetSimpleDocumentItem_Click(object sender, KeyEventArgs e)
        {
            var providersList = _providerLogic.ReadList(null);
            var documentTitle = "Заголовок документа";
            var tablesList = new List<string[,]> {};

            for (int i = 0; i < providersList.Count(); i++)
            {
                var table = new string[7,2];
                table[0, 0] = providersList[i].Name;
                table[1, 0] = "№ Поставки";
                table[1, 1] = "Поставка";
                int k = 2;
                string[] providerIdsArray = providersList[i].LastShipping.Split(';');
                for (int j = 0; j < 5; j++)
                {
                    table[k, 0] = (j + 1).ToString();
                    table[k, 1] = providerIdsArray[j];
                    k++;
                }
                tablesList.Add(table);
            }


            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    customComponentForXlsTable.GenerateExcelDocument(saveFileDialog.FileName, documentTitle, tablesList);
                    MessageBox.Show(
                        "Excel-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании Excel-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void GetTableDocumentItem_Click(object sender, KeyEventArgs e)
        {
            var providersList = _providerLogic.ReadList(null);

            ComponentDocumentWithTableHeaderDataConfig<ProviderViewModel> config = new()
            {
                Header = "Заголовок",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Идент.", "Id"),
                    (1, 0, "Название", "Name"),
                    (2, 0, "Сводка", ""),
                    (2, 1, "ФИО Менеджера", "Manager"),
                    (3, 1, "Частота поставок в год", "DeliveryFrequencyPerYear"),
                },
                Data = providersList
            };

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Word Files|*.docx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                config.FilePath = saveFileDialog.FileName;

                try
                {
                    componentDocumentWithTableHeaderColumnWord.CreateDoc(config);
                    MessageBox.Show(
                        "Word-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании Word-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void GetDiagramDocumentItem_Click(object sender, KeyEventArgs e)
        {

            var providersList = _providerLogic.ReadList(null);
            var groupedData = providersList
                .GroupBy(provider => provider.Manager)
                .Select(group => new
                {
                    Manager = group.Key,
                    Providers = group.ToList()
                })
                .ToList();
            PdfWithDiagramData config = new()
            {
                DocumentTitle = "Заголовок",
                DiagramName = "Линейная диаграмма",
                LegendPosition = DiagramLegendPosition.BottomCenterOutside,
            };

            foreach (var manager in groupedData)
            {
                int[] list = new int[13];
                foreach(var provider in manager.Providers)
                {
                    list[provider.DeliveryFrequencyPerYear]++;
                }
                var listData = new List<(double, double)> { };
                for(int i = 0; i < list.Length; i++)
                {
                    listData.Add((Double.Parse(i.ToString()), Double.Parse(list[i].ToString())));
                }
                config.Series.Add(new()
                {
                    Name = manager.Manager,    
                    Data = listData,
                });
            }

            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PDF Files|*.pdf"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                config.FilePath = saveFileDialog.FileName;
                try
                {
                    pdfGeneratorLinearDiagram.GeneratePdfDocumentWithChart(config);
                    MessageBox.Show(
                        "Pdf-документ успешно сохранен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при создании Pdf-документа: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }






        private void OpenListManager_Click(object sender, KeyEventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormManager));
            if (service is FormManager form)
            {
                form.ShowDialog();
                LoadData();
            }
        }
    }
}
