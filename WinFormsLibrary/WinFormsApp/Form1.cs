using System;
using WinFormsLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //��������� ������
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            userControl11.ClearList();
        }

        private void buttonAddValue_Click(object sender, EventArgs e)
        {
            userControl11.AddValueToListBox.Add("�������� 1");
            userControl11.AddValueToListBox.Add("�������� 2");
            userControl11.AddValueToListBox.Add("�������� 3");
            userControl11.AddValueToListBox.Add("�������� 4");
            userControl11.AddValueToListBox.Add("�������� 5");
        }

        private void buttonSelectedValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show(userControl11.SelectedValue);
        }

        private void UserControl1_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedValue = userControl11.SelectedValue;
            MessageBox.Show("����� ��������: " + selectedValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControl11.SelectedValueChanged += UserControl1_SelectedValueChanged;
            customTextBox1.CheckBoxValueChanged += checkBoxDate_SelectedValueChanged;
        }

        //��������� �����

        private void buttonGet_Click(object sender, EventArgs e)
        {
            textBoxGet.Text = customTextBox1.DateValue.ToString();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if(textBoxSet.Text == "")
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
            MessageBox.Show("CheckBox ���������");
        }

        private void buttonAddConfig_Click(object sender, EventArgs e)
        {
            var columnConfigs = new List<GridColumnConfig>
            {
                new GridColumnConfig { HeaderText = "���", Width = 100, Visible = true, PropertyName = "Name" },
                new GridColumnConfig { HeaderText = "�������", Width = 80, Visible = true, PropertyName = "Age" },
                new GridColumnConfig { HeaderText = "����", Width = 80, Visible = true, PropertyName = "Height" },
            };

            customDataGridView1.ConfigureColumns(columnConfigs);
        }

        private void buttonAddCells_Click(object sender, EventArgs e)
        {
            Person person1 = new Person("����", 30, 180);
            Person person2 = new Person("����", 18, 170);
            Person person3 = new Person("����", 20, 175);

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
    }
}