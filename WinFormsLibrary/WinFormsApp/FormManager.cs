using Contracts.BindingModels;
using Contracts.BusinessLogicContracts;
using Contracts.SearchModels;
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
    public partial class FormManager : Form
    {
        private readonly IManagerLogic _managerLogic;
        bool isEdit = false;
        public FormManager(IManagerLogic managerLogic)
        {
            InitializeComponent();
            _managerLogic = managerLogic;
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var managers = _managerLogic.ReadList(null);
                if (managers != null)
                {
                    dataGridView.DataSource = managers;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns["Surname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    AddType();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    RemoveType();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    isEdit = true;
                    SaveChanges_Click();
                    e.Handled = true;
                    break;
            }
        }

        private void SaveChanges_Click()
        {
            if (isEdit)
            {
                SaveChanges();
                isEdit = false;
            }
        }

        private void AddType()
        {
            var list = _managerLogic.ReadList(null);
            list.Add(new());
            if (list != null)
            {
                dataGridView.DataSource = list;
                dataGridView.Columns["Id"].Visible = false;
                dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns["Surname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void RemoveType()
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить выбранные записи?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            int id = Convert.ToInt32(row.Cells["Id"].Value);
                            var view = _managerLogic.ReadElement(new ManagerSearchModel
                            {
                                Id = id
                            });
                            _managerLogic.Delete(view);
                        }
                    }
                    LoadData();
                }
            }
        }

        private void SaveChanges()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string? name = row.Cells["Name"].Value?.ToString();
                    string? surname = row.Cells["Surname"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname))
                    {
                        var model = new ManagerBindingModel
                        {
                            Id = id,
                            Name = name,
                            Surname = surname,
                        };

                        if (model.Id == 0)
                        {
                            _managerLogic.Create(model);
                        }
                        else
                        {
                            _managerLogic.Update(model);
                        }
                    }
                }
            }

            LoadData();
        }
    }
}
