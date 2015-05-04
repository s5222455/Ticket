namespace Ticket
{
    partial class FrmSelectPassenger
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueryPassenger = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadPassengers = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPassenger = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lvSelectPassengers = new System.Windows.Forms.ListView();
            this.btnImportPassenger = new System.Windows.Forms.Button();
            this.btnAddPassenger = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.ColIndex = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPassengerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPassengerState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOper = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "快速检索：";
            // 
            // txtQueryPassenger
            // 
            this.txtQueryPassenger.Location = new System.Drawing.Point(72, 6);
            this.txtQueryPassenger.Name = "txtQueryPassenger";
            this.txtQueryPassenger.Size = new System.Drawing.Size(148, 21);
            this.txtQueryPassenger.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "*可输入首字母拼音，全拼和中文，清空则显示全部";
            // 
            // btnLoadPassengers
            // 
            this.btnLoadPassengers.Location = new System.Drawing.Point(644, 4);
            this.btnLoadPassengers.Name = "btnLoadPassengers";
            this.btnLoadPassengers.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPassengers.TabIndex = 3;
            this.btnLoadPassengers.Text = "重新获取";
            this.btnLoadPassengers.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(641, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "乘客信息核验状态：已通过 请报验 预通过 待审核 未通过。(仅已通过，请报验，预通过可正常购票,点击 查看详情。)";
            // 
            // dgvPassenger
            // 
            this.dgvPassenger.AllowUserToAddRows = false;
            this.dgvPassenger.AllowUserToDeleteRows = false;
            this.dgvPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIndex,
            this.ColName,
            this.ColIdType,
            this.ColIdNo,
            this.ColMobileNo,
            this.ColPassengerType,
            this.ColPassengerState,
            this.ColOper});
            this.dgvPassenger.Location = new System.Drawing.Point(12, 45);
            this.dgvPassenger.Name = "dgvPassenger";
            this.dgvPassenger.ReadOnly = true;
            this.dgvPassenger.RowTemplate.Height = 23;
            this.dgvPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassenger.Size = new System.Drawing.Size(707, 379);
            this.dgvPassenger.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "已选择：";
            // 
            // lvSelectPassengers
            // 
            this.lvSelectPassengers.Location = new System.Drawing.Point(66, 435);
            this.lvSelectPassengers.Name = "lvSelectPassengers";
            this.lvSelectPassengers.Size = new System.Drawing.Size(653, 25);
            this.lvSelectPassengers.TabIndex = 7;
            this.lvSelectPassengers.UseCompatibleStateImageBehavior = false;
            // 
            // btnImportPassenger
            // 
            this.btnImportPassenger.Location = new System.Drawing.Point(12, 469);
            this.btnImportPassenger.Name = "btnImportPassenger";
            this.btnImportPassenger.Size = new System.Drawing.Size(75, 23);
            this.btnImportPassenger.TabIndex = 8;
            this.btnImportPassenger.Text = "批量添加";
            this.btnImportPassenger.UseVisualStyleBackColor = true;
            // 
            // btnAddPassenger
            // 
            this.btnAddPassenger.Location = new System.Drawing.Point(102, 469);
            this.btnAddPassenger.Name = "btnAddPassenger";
            this.btnAddPassenger.Size = new System.Drawing.Size(75, 23);
            this.btnAddPassenger.TabIndex = 9;
            this.btnAddPassenger.Text = "添加";
            this.btnAddPassenger.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(643, 469);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(553, 469);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "确定";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // ColIndex
            // 
            this.ColIndex.HeaderText = "序号";
            this.ColIndex.Name = "ColIndex";
            this.ColIndex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIndex.Width = 50;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "姓名";
            this.ColName.Name = "ColName";
            this.ColName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Width = 60;
            // 
            // ColIdType
            // 
            this.ColIdType.HeaderText = "证件类型";
            this.ColIdType.Name = "ColIdType";
            this.ColIdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIdType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColIdType.Width = 80;
            // 
            // ColIdNo
            // 
            this.ColIdNo.HeaderText = "证件号码";
            this.ColIdNo.Name = "ColIdNo";
            this.ColIdNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIdNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColIdNo.Width = 120;
            // 
            // ColMobileNo
            // 
            this.ColMobileNo.HeaderText = "手机号";
            this.ColMobileNo.Name = "ColMobileNo";
            this.ColMobileNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColMobileNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPassengerType
            // 
            this.ColPassengerType.HeaderText = "乘客类型";
            this.ColPassengerType.Name = "ColPassengerType";
            this.ColPassengerType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPassengerType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPassengerType.Width = 80;
            // 
            // ColPassengerState
            // 
            this.ColPassengerState.HeaderText = "核验状态";
            this.ColPassengerState.Name = "ColPassengerState";
            this.ColPassengerState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPassengerState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPassengerState.Width = 80;
            // 
            // ColOper
            // 
            this.ColOper.HeaderText = "操作";
            this.ColOper.Name = "ColOper";
            this.ColOper.Width = 70;
            // 
            // FrmSelectPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 504);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnAddPassenger);
            this.Controls.Add(this.btnImportPassenger);
            this.Controls.Add(this.lvSelectPassengers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvPassenger);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadPassengers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQueryPassenger);
            this.Controls.Add(this.label1);
            this.Name = "FrmSelectPassenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择乘客";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQueryPassenger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadPassengers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPassenger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvSelectPassengers;
        private System.Windows.Forms.Button btnImportPassenger;
        private System.Windows.Forms.Button btnAddPassenger;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPassengerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPassengerState;
        private System.Windows.Forms.DataGridViewLinkColumn ColOper;
    }
}