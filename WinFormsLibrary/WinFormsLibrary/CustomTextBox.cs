using System;
using System.Windows.Forms;

namespace WinFormsLibrary
{
    public partial class CustomTextBox : UserControl
    {
        public event EventHandler ValueChanged;
        public string Error { get; private set; }

        public CustomTextBox()
        {
            InitializeComponent();
            CustomInitialize();
            Error = string.Empty;
        }

        public void CustomInitialize()
        {
            checkBoxDate.CheckedChanged += (sender, e) =>
            {
                textBoxDate.Enabled = !checkBoxDate.Checked;
                if (checkBoxDate.Checked)
                {
                    textBoxDate.Text = string.Empty;
                }
            };

            textBoxDate.TextChanged += (sender, e) =>
            {
                OnValueChanged(EventArgs.Empty);
            };
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = ValueChanged;
            handler?.Invoke(this, e);
        }

        public DateTime? DateValue
        {
            get
            {
                if (!checkBoxDate.Checked || string.IsNullOrWhiteSpace(textBoxDate.Text))
                {
                    Error = "Галочка не проставлена или не введено значение";
                    return null;
                }

                if (DateTime.TryParseExact(textBoxDate.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
                else
                {
                    Error = "Введенное значение не соответствует требуемому формату (dd.MM.yyyy)";
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    textBoxDate.Text = value.Value.ToString("dd.MM.yyyy");
                    checkBoxDate.Checked = false;
                }
                else
                {
                    textBoxDate.Text = string.Empty;
                    checkBoxDate.Checked = true;
                }
            }
        }

        public event EventHandler CustomValueChanged
        {
            add
            {
                checkBoxDate.CheckedChanged += value;
                textBoxDate.TextChanged += value;
            }
            remove
            {
                checkBoxDate.CheckedChanged -= value;
                textBoxDate.TextChanged -= value;
            }
        }
    }
}
