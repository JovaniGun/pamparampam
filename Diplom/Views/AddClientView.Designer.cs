namespace Diplom.Views
{
    partial class AddClientView
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
            this.FIOtextBox = new System.Windows.Forms.TextBox();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.phoneBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.agreeCheckBox = new System.Windows.Forms.CheckBox();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавить клиента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ФИО";
            // 
            // FIOtextBox
            // 
            this.FIOtextBox.Location = new System.Drawing.Point(143, 56);
            this.FIOtextBox.Name = "FIOtextBox";
            this.FIOtextBox.Size = new System.Drawing.Size(186, 20);
            this.FIOtextBox.TabIndex = 2;
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.Location = new System.Drawing.Point(143, 96);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(186, 20);
            this.birthdayPicker.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата рождения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Пол";
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(143, 134);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(186, 21);
            this.genderComboBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Email";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(143, 169);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(186, 20);
            this.EmailBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Телефон";
            // 
            // phoneBox
            // 
            this.phoneBox.Location = new System.Drawing.Point(143, 207);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(186, 20);
            this.phoneBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Разрешить рассылку";
            // 
            // agreeCheckBox
            // 
            this.agreeCheckBox.AutoSize = true;
            this.agreeCheckBox.Location = new System.Drawing.Point(143, 242);
            this.agreeCheckBox.Name = "agreeCheckBox";
            this.agreeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.agreeCheckBox.TabIndex = 12;
            this.agreeCheckBox.UseVisualStyleBackColor = true;
            // 
            // submit
            // 
            this.submit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.submit.ForeColor = System.Drawing.SystemColors.InfoText;
            this.submit.Location = new System.Drawing.Point(109, 291);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(144, 32);
            this.submit.TabIndex = 13;
            this.submit.Text = "Добавить";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // AddClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 335);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.agreeCheckBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.birthdayPicker);
            this.Controls.Add(this.FIOtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddClientView";
            this.Text = "AddClientView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FIOtextBox;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox phoneBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox agreeCheckBox;
        private System.Windows.Forms.Button submit;
    }
}