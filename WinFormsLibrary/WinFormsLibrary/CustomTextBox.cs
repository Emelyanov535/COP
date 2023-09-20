using System;
using System.Windows.Forms;

namespace WinFormsLibrary
{
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
        }

        public class InvalidDateFormatException : Exception
        {
            public InvalidDateFormatException(string message) : base(message)
            {
            }
        }

        public DateTime? DateValue
        {
            get
            {
                if (!checkBoxDate.Checked || string.IsNullOrWhiteSpace(textBoxDate.Text))
                {
                    throw new InvalidDateFormatException("Галочка не проставлена или не введено значени");
                }

                if (DateTime.TryParseExact(textBoxDate.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                {
                    return result;
                }
                else
                {
                    throw new InvalidDateFormatException("Введенное значение не соответствует требуемому формату (dd.MM.yyyy)");
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

        public event EventHandler CheckBoxValueChanged
        {
            add
            {
                checkBoxDate.CheckedChanged += value;
            }
            remove
            {
                checkBoxDate.CheckedChanged -= value;
            }
        }
    }
}
