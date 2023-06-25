namespace Paint.EntryForms
{
    partial class SetPolygonValuesForm
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
            this.sides = new System.Windows.Forms.TextBox();
            this.inscribed = new System.Windows.Forms.ComboBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sides: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status:";
            // 
            // sides
            // 
            this.sides.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sides.Location = new System.Drawing.Point(141, 43);
            this.sides.Name = "sides";
            this.sides.Size = new System.Drawing.Size(208, 32);
            this.sides.TabIndex = 2;
            this.sides.Text = "3";
            this.sides.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sides_KeyPress);
            // 
            // inscribed
            // 
            this.inscribed.FormattingEnabled = true;
            this.inscribed.Items.AddRange(new object[] {
            "Inscribed in circle",
            "Circumscribed about circle"});
            this.inscribed.Location = new System.Drawing.Point(141, 118);
            this.inscribed.Name = "inscribed";
            this.inscribed.Size = new System.Drawing.Size(397, 32);
            this.inscribed.TabIndex = 3;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(279, 183);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(126, 41);
            this.acceptBtn.TabIndex = 4;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(412, 183);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(126, 41);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SetPolygonValuesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(568, 243);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.inscribed);
            this.Controls.Add(this.sides);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetPolygonValuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SetPolygonValuesForm";
            this.Load += new System.EventHandler(this.SetPolygonValuesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sides;
        private System.Windows.Forms.ComboBox inscribed;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}