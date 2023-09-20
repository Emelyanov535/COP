namespace WinFormsLibrary
{
    partial class CustomListBox
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.customListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // customListBox
            // 
            this.customListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customListBox.FormattingEnabled = true;
            this.customListBox.ItemHeight = 15;
            this.customListBox.Location = new System.Drawing.Point(3, 3);
            this.customListBox.Name = "customListBox";
            this.customListBox.Size = new System.Drawing.Size(144, 139);
            this.customListBox.TabIndex = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customListBox);
            this.Name = "UserControl1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox customListBox;
    }
}
