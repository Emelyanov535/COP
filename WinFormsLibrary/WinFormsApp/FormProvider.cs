using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
using Contracts.StoragesContracts;
using ControlsLibraryNet60.Data;
using ControlsLibraryNet60.Input;
using ControlsLibraryNet60.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormProvider : Form
    {
        private readonly IProviderLogic _providerLogic;
        private readonly IManagerLogic _managerLogic;
        private readonly IProviderStorage _providerStorage;
        private int? _id;
        public int Id { set { _id = value; } }
        private bool isEdited;
        public FormProvider(IManagerLogic managerLogic, IProviderLogic providerLogic, IProviderStorage providerStorage)
        {
            InitializeComponent();
            _managerLogic = managerLogic;
            _providerLogic = providerLogic;
            _providerStorage = providerStorage;
            isEdited = false;
        }

        private void FormProvider_Load(object sender, EventArgs e)
        {
            LoadData();
            if (_id.HasValue)
            {
                try
                {
                    var element = _providerStorage.GetElement(new ProviderSearchModel
                    {
                        Id = _id.Value,
                    });
                    if (element != null)
                    {
                        textBox.Text = element.Name;
                        controlInputRangeNumber.Value = element.DeliveryFrequencyPerYear;
                        customListBox.SelectedValue = element.Manager;
                        textBox1.Text = element.LastShipping;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            isEdited = false;
        }

        private void LoadData()
        {
            try
            {
                var list = _managerLogic.ReadList(null);
                if (list != null)
                {
                    for(int i = 0; i < list.Count(); i++)
                    {
                        customListBox.AddValueToListBox.Add(list[i].Name + " " + list[i].Surname);
                    }  
                }
                if (_id.HasValue)
                {
                    var view = _providerStorage.GetElement(new ProviderSearchModel
                    {
                        Id = _id!.Value
                    });
                    customListBox.SelectedValue = view!.Manager;
                }
                isEdited = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            isEdited = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Название не указано");
                return;
            }
            if (string.IsNullOrEmpty(controlInputRangeNumber.Value.ToString()))
            {
                MessageBox.Show("Кол-во поставок в год не указано");
                return;
            }
            if (string.IsNullOrEmpty(customListBox.SelectedValue))
            {
                MessageBox.Show("Менеджер не выбран");
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Даты последних поставок не указаны");
                return;
            }
            isEdited = false;
            try
            {
                var model = new ProviderBindingModel
                {
                    Id = _id ?? 0,
                    Name = textBox.Text,
                    DeliveryFrequencyPerYear = (int)controlInputRangeNumber.Value,
                    Manager = customListBox.SelectedValue,
                    LastShipping = textBox1.Text,
                };
                var action = _id.HasValue ? _providerLogic.Update(model) : _providerLogic.Create(model);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnInputChange(
            object sender,
            EventArgs e
        )
        {
            isEdited = true;
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FormProvider_FormClosing(
           object sender,
           FormClosingEventArgs e
       )
        {
            if (!isEdited) return;
            var confirmResult = MessageBox.Show(
                "Имеются незафиксированные изменения." +
                "\n" +
                "Вы действительно хотите закрыть форму?",
                "Подтвердите действие",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmResult == DialogResult.No) e.Cancel = true;
        }
    }
}
