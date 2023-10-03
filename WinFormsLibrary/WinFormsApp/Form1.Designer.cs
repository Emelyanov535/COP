namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.userControl11 = new WinFormsLibrary.CustomListBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonAddValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectedValue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.customTextBox1 = new WinFormsLibrary.CustomTextBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.textBoxGet = new System.Windows.Forms.TextBox();
            this.textBoxSet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customDataGridView1 = new WinFormsLibrary.CustomDataGridView();
            this.buttonAddConfig = new System.Windows.Forms.Button();
            this.buttonAddCells = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonGetSelected = new System.Windows.Forms.Button();
            this.customComponentForXlsTable1 = new WinFormsLibrary.CustomComponentForXlsTable(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.componentWithSettings1 = new WinFormsLibrary.not_visual.ComponentWithSettings(this.components);
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(31, 129);
            this.userControl11.Name = "userControl11";
            this.userControl11.SelectedValue = "";
            this.userControl11.Size = new System.Drawing.Size(150, 150);
            this.userControl11.TabIndex = 3;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(31, 314);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(150, 23);
            this.buttonClearListBox.TabIndex = 1;
            this.buttonClearListBox.Text = "Очистить";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonAddValue
            // 
            this.buttonAddValue.Location = new System.Drawing.Point(31, 285);
            this.buttonAddValue.Name = "buttonAddValue";
            this.buttonAddValue.Size = new System.Drawing.Size(150, 23);
            this.buttonAddValue.TabIndex = 2;
            this.buttonAddValue.Text = "Добавить";
            this.buttonAddValue.UseVisualStyleBackColor = true;
            this.buttonAddValue.Click += new System.EventHandler(this.buttonAddValue_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 107);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список значений.\r\nСписок\r\nзаполняется через\r\nпубличное\r\nсвойство.\r\n\r\n";
            // 
            // buttonSelectedValue
            // 
            this.buttonSelectedValue.Location = new System.Drawing.Point(31, 348);
            this.buttonSelectedValue.Name = "buttonSelectedValue";
            this.buttonSelectedValue.Size = new System.Drawing.Size(150, 23);
            this.buttonSelectedValue.TabIndex = 5;
            this.buttonSelectedValue.Text = "Выбранное значение";
            this.buttonSelectedValue.UseVisualStyleBackColor = true;
            this.buttonSelectedValue.Click += new System.EventHandler(this.buttonSelectedValue_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(321, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 107);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поле для ввода даты\r\n(формат\r\nDD.MM.YYYY) с\r\nвозможностью\r\nуказания значения\r\nnul" +
    "l\r\n";
            // 
            // customTextBox1
            // 
            this.customTextBox1.DateValue = null;
            this.customTextBox1.Location = new System.Drawing.Point(321, 129);
            this.customTextBox1.Name = "customTextBox1";
            this.customTextBox1.Size = new System.Drawing.Size(150, 150);
            this.customTextBox1.TabIndex = 12;
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(416, 314);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(83, 23);
            this.buttonGet.TabIndex = 8;
            this.buttonGet.Text = "Получить";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(416, 344);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(83, 23);
            this.buttonSet.TabIndex = 9;
            this.buttonSet.Text = "Установить";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // textBoxGet
            // 
            this.textBoxGet.Location = new System.Drawing.Point(310, 314);
            this.textBoxGet.Name = "textBoxGet";
            this.textBoxGet.Size = new System.Drawing.Size(100, 23);
            this.textBoxGet.TabIndex = 10;
            // 
            // textBoxSet
            // 
            this.textBoxSet.Location = new System.Drawing.Point(310, 343);
            this.textBoxSet.Name = "textBoxSet";
            this.textBoxSet.Size = new System.Drawing.Size(100, 23);
            this.textBoxSet.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(620, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 107);
            this.label3.TabIndex = 13;
            this.label3.Text = "Таблица значений.\r\nТаблица заполняется\r\nчерез метод,\r\nпередающий объект,\r\nномер с" +
    "троки и номер\r\nстолбца";
            // 
            // customDataGridView1
            // 
            this.customDataGridView1.Location = new System.Drawing.Point(559, 129);
            this.customDataGridView1.Name = "customDataGridView1";
            this.customDataGridView1.SelectedRowIndex = -1;
            this.customDataGridView1.Size = new System.Drawing.Size(335, 190);
            this.customDataGridView1.TabIndex = 14;
            // 
            // buttonAddConfig
            // 
            this.buttonAddConfig.Location = new System.Drawing.Point(642, 342);
            this.buttonAddConfig.Name = "buttonAddConfig";
            this.buttonAddConfig.Size = new System.Drawing.Size(131, 23);
            this.buttonAddConfig.TabIndex = 15;
            this.buttonAddConfig.Text = "Конфигурация";
            this.buttonAddConfig.UseVisualStyleBackColor = true;
            this.buttonAddConfig.Click += new System.EventHandler(this.buttonAddConfig_Click);
            // 
            // buttonAddCells
            // 
            this.buttonAddCells.Location = new System.Drawing.Point(642, 371);
            this.buttonAddCells.Name = "buttonAddCells";
            this.buttonAddCells.Size = new System.Drawing.Size(131, 23);
            this.buttonAddCells.TabIndex = 16;
            this.buttonAddCells.Text = "Добавить значения";
            this.buttonAddCells.UseVisualStyleBackColor = true;
            this.buttonAddCells.Click += new System.EventHandler(this.buttonAddCells_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(642, 400);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(131, 23);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(789, 342);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(75, 23);
            this.buttonGetSelected.TabIndex = 18;
            this.buttonGetSelected.Text = "Получить выбранное";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 592);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGetSelected);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAddCells);
            this.Controls.Add(this.buttonAddConfig);
            this.Controls.Add(this.customDataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSet);
            this.Controls.Add(this.textBoxGet);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.customTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSelectedValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddValue);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinFormsLibrary.CustomListBox userControl11;
        private Button buttonClearListBox;
        private Button buttonAddValue;
        private Label label1;
        private Button buttonSelectedValue;
        private Label label2;
        private WinFormsLibrary.CustomTextBox customTextBox1;
        private Button buttonGet;
        private Button buttonSet;
        private TextBox textBoxGet;
        private TextBox textBoxSet;
        private Label label3;
        private WinFormsLibrary.CustomDataGridView customDataGridView1;
        private Button buttonAddConfig;
        private Button buttonAddCells;
        private Button buttonClear;
        private Button buttonGetSelected;
        private WinFormsLibrary.CustomComponentForXlsTable customComponentForXlsTable1;
        private Button button1;
        private Button button2;
        private WinFormsLibrary.not_visual.ComponentWithSettings componentWithSettings1;
    }
}