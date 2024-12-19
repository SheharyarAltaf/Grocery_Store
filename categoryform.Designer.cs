namespace grocery_store
{
    partial class categoryform
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCatId = new System.Windows.Forms.TextBox();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.rdoavailable = new System.Windows.Forms.RadioButton();
            this.rdoUnavailable = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cat ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CatName";
            // 
            // txtCatId
            // 
            this.txtCatId.Location = new System.Drawing.Point(115, 38);
            this.txtCatId.Name = "txtCatId";
            this.txtCatId.Size = new System.Drawing.Size(100, 20);
            this.txtCatId.TabIndex = 2;
            this.txtCatId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCatId_KeyPress);
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(115, 80);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(100, 20);
            this.txtCatName.TabIndex = 3;
            // 
            // rdoavailable
            // 
            this.rdoavailable.AutoSize = true;
            this.rdoavailable.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rdoavailable.Checked = true;
            this.rdoavailable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdoavailable.Location = new System.Drawing.Point(27, 159);
            this.rdoavailable.Name = "rdoavailable";
            this.rdoavailable.Size = new System.Drawing.Size(68, 17);
            this.rdoavailable.TabIndex = 4;
            this.rdoavailable.TabStop = true;
            this.rdoavailable.Text = "Available";
            this.rdoavailable.UseVisualStyleBackColor = false;
            // 
            // rdoUnavailable
            // 
            this.rdoUnavailable.AutoSize = true;
            this.rdoUnavailable.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rdoUnavailable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdoUnavailable.Location = new System.Drawing.Point(27, 201);
            this.rdoUnavailable.Name = "rdoUnavailable";
            this.rdoUnavailable.Size = new System.Drawing.Size(81, 17);
            this.rdoUnavailable.TabIndex = 5;
            this.rdoUnavailable.Text = "Unavailable";
            this.rdoUnavailable.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Teal;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(27, 258);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Teal;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(126, 258);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvCategory
            // 
            this.dgvCategory.BackgroundColor = System.Drawing.Color.Teal;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Location = new System.Drawing.Point(231, 94);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.Size = new System.Drawing.Size(454, 258);
            this.dgvCategory.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Uighur", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 35);
            this.label3.TabIndex = 9;
            this.label3.Text = "Category Lists";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // categoryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 393);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCategory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rdoUnavailable);
            this.Controls.Add(this.rdoavailable);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.txtCatId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "categoryform";
            this.Text = "categoryform";
            this.Load += new System.EventHandler(this.categoryform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCatId;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.RadioButton rdoavailable;
        private System.Windows.Forms.RadioButton rdoUnavailable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Label label3;
    }
}