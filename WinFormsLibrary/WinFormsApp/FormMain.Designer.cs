namespace WinFormsApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.componentDocumentWithTableHeaderColumnWord = new ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableHeaderColumnWord(this.components);
            this.customComponentForXlsTable = new WinFormsLibrary.CustomComponentForXlsTable(this.components);
            this.listBoxValues = new WinForm.ListBoxValues();
            this.pdfGeneratorLinearDiagram = new WinFormsLibrary.PdfGeneratorLinearDiagram(this.components);
            this.SuspendLayout();
            // 
            // listBoxValues
            // 
            this.listBoxValues.Location = new System.Drawing.Point(12, 12);
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.SelectedIndex = -1;
            this.listBoxValues.Size = new System.Drawing.Size(639, 314);
            this.listBoxValues.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 338);
            this.Controls.Add(this.listBoxValues);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentsLibraryNet60.DocumentWithTable.ComponentDocumentWithTableHeaderColumnWord componentDocumentWithTableHeaderColumnWord;
        private WinFormsLibrary.CustomComponentForXlsTable customComponentForXlsTable;
        private WinForm.ListBoxValues listBoxValues;
        private WinFormsLibrary.PdfGeneratorLinearDiagram pdfGeneratorLinearDiagram;
    }
}