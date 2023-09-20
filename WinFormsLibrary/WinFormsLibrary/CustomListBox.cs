using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLibrary
{
    public partial class CustomListBox : UserControl
    {
        public CustomListBox()
        {
            InitializeComponent();
        }

        //Публичное свойство для заполнения
        public ListBox.ObjectCollection AddValueToListBox
        {
            get { 
                return customListBox.Items; 
            }
            set
            {
                customListBox.Items.AddRange(value);
            }
        }

        // Метод для очистки списка
        public void ClearList()
        {
            customListBox.Items.Clear();
        }

        // Публичное свойство для получения и установки выбранного значения
        public string SelectedValue
        {
            get
            {
                if (customListBox.SelectedItem != null)
                {
                    return customListBox.SelectedItem.ToString();
                }
                return string.Empty;
            }
            set
            {
                customListBox.SelectedItem = value;
            }
        }

        // Событие для смены значения в ListBox
        public event EventHandler SelectedValueChanged
        {
            add
            {
                customListBox.SelectedIndexChanged += value;
            }
            remove
            {
                customListBox.SelectedIndexChanged -= value;
            }
        }
    }
}
