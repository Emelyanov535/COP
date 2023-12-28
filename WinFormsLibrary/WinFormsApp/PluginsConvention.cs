using BusinessLogic;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using Contracts.BusinessLogicContracts;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DataBase.Implements;
using PluginsConventionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm;
using WinFormsLibrary;
using WinFormsLibrary.Helpers;

namespace WinFormsApp
{
    public class PluginsConvention : IPluginsConvention
    {
        private readonly IProviderLogic _providerLogic = new ProviderLogic(new ProviderStorage());
        private readonly IManagerLogic _managerLogic = new ManagerLogic(new ManagerStorage());
        private readonly IProviderStorage _providerStorage = new ProviderStorage();
        public ListBoxValues listBoxValues = new ListBoxValues();

        public string PluginName { get; set; } = "Название для плагина";

        public UserControl GetControl {
            get
            {
                LoadData();
                return listBoxValues;
            }
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

        public PluginsConventionElement GetElement
        {
            get
            {
                int Id = listBoxValues.GetObjectFromStr<ProviderViewModel>().Id;
                byte[] bytes = new byte[16];
                BitConverter.GetBytes(Id).CopyTo(bytes, 0);
                Guid guid = new Guid(bytes);
                return new PluginsConventionElement() { Id = guid };
            }
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                PdfGeneratorLinearDiagram pdfGeneratorLinearDiagram = new PdfGeneratorLinearDiagram();
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
                    foreach (var provider in manager.Providers)
                    {
                        list[provider.DeliveryFrequencyPerYear]++;
                    }
                    var listData = new List<(double, double)> { };
                    for (int i = 0; i < list.Length; i++)
                    {
                        listData.Add((Double.Parse(i.ToString()), Double.Parse(list[i].ToString())));
                    }
                    config.Series.Add(new()
                    {
                        Name = manager.Manager,
                        Data = listData,
                    });
                }
                config.FilePath = saveDocument.FileName;
                pdfGeneratorLinearDiagram.GeneratePdfDocumentWithChart(config);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                CustomComponentForXlsTable customComponentForXlsTable = new CustomComponentForXlsTable();
                var providersList = _providerLogic.ReadList(null);
                var documentTitle = "Заголовок документа";
                var tablesList = new List<string[,]> { };

                for (int i = 0; i < providersList.Count(); i++)
                {
                    var table = new string[7, 2];
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
                customComponentForXlsTable.GenerateExcelDocument(saveDocument.FileName, documentTitle, tablesList);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                ComponentDocumentWithTableHeaderColumnWord componentDocumentWithTableHeaderColumnWord = new ComponentDocumentWithTableHeaderColumnWord();
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
                config.FilePath = saveDocument.FileName;
                componentDocumentWithTableHeaderColumnWord.CreateDoc(config);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            if (listBoxValues.GetObjectFromStr<ProviderViewModel>() == null) return false;
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
            return true;
        }

        public Form GetForm(PluginsConventionElement element)
        {
            if (element == null)
            {
                return new FormProvider(_managerLogic, _providerLogic, _providerStorage);
            }
            else
            {
                FormProvider form = new FormProvider(_managerLogic, _providerLogic, _providerStorage);
                form.Id = element.Id.GetHashCode();
                return form;
            }
        }

        public Form GetThesaurus()
        {
            return new FormManager(_managerLogic);
        }

        public void ReloadData()
        {
            LoadData();
        }
    }
}
