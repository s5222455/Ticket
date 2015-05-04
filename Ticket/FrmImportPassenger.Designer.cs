namespace Ticket
{
    partial class FrmImportPassenger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportPassenger));
            this.rtxtPassenger = new System.Windows.Forms.RichTextBox();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.rtxtInstructions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtPassenger
            // 
            this.rtxtPassenger.Location = new System.Drawing.Point(12, 145);
            this.rtxtPassenger.Name = "rtxtPassenger";
            this.rtxtPassenger.Size = new System.Drawing.Size(626, 128);
            this.rtxtPassenger.TabIndex = 0;
            this.rtxtPassenger.Text = "";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(479, 283);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(560, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 283);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(122, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "从文本文件中导入";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // rtxtInstructions
            // 
            this.rtxtInstructions.Location = new System.Drawing.Point(12, 12);
            this.rtxtInstructions.Name = "rtxtInstructions";
            this.rtxtInstructions.Size = new System.Drawing.Size(626, 127);
            this.rtxtInstructions.TabIndex = 4;
            this.rtxtInstructions.Text = resources.GetString("rtxtInstructions.Text");
            // 
            // FrmImportPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 318);
            this.Controls.Add(this.rtxtInstructions);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.rtxtPassenger);
            this.Name = "FrmImportPassenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量导入乘客";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtPassenger;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.RichTextBox rtxtInstructions;
    }
}