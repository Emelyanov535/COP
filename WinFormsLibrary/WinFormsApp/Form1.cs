using System;
using WinFormsLibrary.not_visual;
using WinFormsLibrary.visual;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WinFormsLibrary.not_visual.Gistograma;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Компонент выбора
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            userControl11.ClearList();
        }

        private void buttonAddValue_Click(object sender, EventArgs e)
        {
            userControl11.AddValueToListBox.Add("Значение 1");
            userControl11.AddValueToListBox.Add("Значение 2");
            userControl11.AddValueToListBox.Add("Значение 3");
            userControl11.AddValueToListBox.Add("Значение 4");
            userControl11.AddValueToListBox.Add("Значение 5");
        }

        private void buttonSelectedValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show(userControl11.SelectedValue);
        }

        private void UserControl1_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = userControl11.SelectedValue;
            MessageBox.Show("Смена значения: " + selectedValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControl11.SelectedValueChanged += UserControl1_SelectedValueChanged;
            /* customTextBox1.CustomValueChanged += checkBoxDate_SelectedValueChanged;*/
        }

        //Компонент ввода

        private void buttonGet_Click(object sender, EventArgs e)
        {
            textBoxGet.Text = customTextBox1.DateValue.ToString();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBoxSet.Text == "")
            {
                customTextBox1.DateValue = null;
            }
            else
            {
                customTextBox1.DateValue = DateTime.ParseExact(textBoxSet?.Text, "dd.MM.yyyy", null);
            }
        }

        private void checkBoxDate_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("CheckBox поменялся");
        }

        private void buttonAddConfig_Click(object sender, EventArgs e)
        {
            var columnConfigs = new List<GridColumnConfig>
            {
                new GridColumnConfig { HeaderText = "Имя", Width = 100, Visible = true, PropertyName = "Name" },
                new GridColumnConfig { HeaderText = "Возраст", Width = 80, Visible = true, PropertyName = "Age" },
                new GridColumnConfig { HeaderText = "Рост", Width = 80, Visible = true, PropertyName = "Height" },
            };

            customDataGridView1.ConfigureColumns(columnConfigs);
        }

        private void buttonAddCells_Click(object sender, EventArgs e)
        {
            Person person1 = new Person("Иван", 30, 180);
            Person person2 = new Person("Саша", 18, 170);
            Person person3 = new Person("Петя", 20, 175);

            customDataGridView1.SetCellValueFromObject(person1, 0, 2);
            customDataGridView1.SetCellValueFromObject(person2, 1, 2);
            customDataGridView1.SetCellValueFromObject(person3, 2, 2);

            customDataGridView1.SetCellValueFromObject(person1, 0, 1);
            customDataGridView1.SetCellValueFromObject(person2, 1, 1);
            customDataGridView1.SetCellValueFromObject(person3, 2, 1);

            customDataGridView1.SetCellValueFromObject(person1, 0, 0);
            customDataGridView1.SetCellValueFromObject(person2, 1, 0);
            customDataGridView1.SetCellValueFromObject(person3, 2, 0);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customDataGridView1.ClearRows();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            MessageBox.Show((customDataGridView1.GetSelectedObject<Person>()).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = "C:\\Users\\Admin\\Desktop\\123.xlsx";
            var documentTitle = "Заголовок документа";
            var tablesList = new List<string[,]>
            {
                new string[,]
                {
                    { "Стр 1 Кол 1", "Стр 1 Кол 2" },
                    { "Стр 2 Кол 1", "Стр 2 Кол 2" },
                    { "Стр 3 Кол 1", "Стр 3 Кол 2" },
                },
                new string[,]
                {
                    { "Стр 1 Кол 1", "Стр 1 Кол 2" },
                    { "Стр 2 Кол 1", "Стр 2 Кол 2" },
                    { "Стр 3 Кол 1", "Стр 3 Кол 2" },
                },
            };
            customComponentForXlsTable1.GenerateExcelDocument(filePath, documentTitle, tablesList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\Admin\\Desktop\\123.xlsx";
            string documentTitle = "Заголовок документа";
            List<string> columnHeaderNames = new List<string> { "Column1", "Column2", "Column3" };
            List<string> rowHeaderNames = new List<string> { "Row1", "Row2", "Row3" };
            List<List<object>> tableData = new List<List<object>>
            {
                new List<object> { "Data1", "Data2", "Data3" },
                new List<object> { "Data4", "Data5", "Data6" },
                new List<object> { "Data7", "Data8", "Data9" }
            };
            componentWithSettings1.GenerateTableDocument(filePath, documentTitle, columnHeaderNames, rowHeaderNames, tableData);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\Admin\\Desktop\\123.xlsx";
            string documentTitle = "Document Title";
            string chartTitle = "Chart Title";

            var chartData = new List<ChartData>
                {
                    new ChartData
                    {
                        SeriesName = "Серия 1",
                        DataPoints = new List<double> { 10, 20, 30, 40, 50 }
                    },
                    new ChartData
                    {
                        SeriesName = "Серия 2",
                        DataPoints = new List<double> { 15, 25, 35, 45, 55 }
                    }
                };


            gistograma1.GenerateChartDocument(filePath, documentTitle, chartTitle, LegendPosition.Bottom, chartData);
        }
    }
}