namespace MedBooking
{
    partial class AdminMenu
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
            this.Lista = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nomeF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.telefoneF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.especialidadeF = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.senhaF = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.usernameF = new System.Windows.Forms.TextBox();
            this.tipoF = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.DeleteId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.ItemHeight = 16;
            this.Lista.Location = new System.Drawing.Point(31, 101);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(417, 212);
            this.Lista.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Achar conta";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(561, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Criar conta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nome :";
            // 
            // nomeF
            // 
            this.nomeF.Location = new System.Drawing.Point(528, 191);
            this.nomeF.Name = "nomeF";
            this.nomeF.Size = new System.Drawing.Size(183, 22);
            this.nomeF.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo da conta :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefone :";
            // 
            // telefoneF
            // 
            this.telefoneF.Location = new System.Drawing.Point(528, 292);
            this.telefoneF.Name = "telefoneF";
            this.telefoneF.Size = new System.Drawing.Size(183, 22);
            this.telefoneF.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Especialidade :";
            // 
            // especialidadeF
            // 
            this.especialidadeF.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.especialidadeF.Location = new System.Drawing.Point(528, 340);
            this.especialidadeF.Name = "especialidadeF";
            this.especialidadeF.Size = new System.Drawing.Size(183, 22);
            this.especialidadeF.TabIndex = 11;
            this.especialidadeF.Text = "apenas para medicos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 35);
            this.button1.TabIndex = 15;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Senha :";
            // 
            // senhaF
            // 
            this.senhaF.Location = new System.Drawing.Point(528, 135);
            this.senhaF.Name = "senhaF";
            this.senhaF.Size = new System.Drawing.Size(183, 22);
            this.senhaF.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Username :";
            // 
            // usernameF
            // 
            this.usernameF.Location = new System.Drawing.Point(528, 87);
            this.usernameF.Name = "usernameF";
            this.usernameF.Size = new System.Drawing.Size(183, 22);
            this.usernameF.TabIndex = 18;
            // 
            // tipoF
            // 
            this.tipoF.DisplayMember = "paciente";
            this.tipoF.FormattingEnabled = true;
            this.tipoF.Items.AddRange(new object[] {
            "paciente",
            "medico"});
            this.tipoF.Location = new System.Drawing.Point(528, 242);
            this.tipoF.Name = "tipoF";
            this.tipoF.Size = new System.Drawing.Size(183, 24);
            this.tipoF.TabIndex = 20;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(357, 368);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(102, 34);
            this.delete.TabIndex = 21;
            this.delete.Text = "Deletar conta";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // DeleteId
            // 
            this.DeleteId.Location = new System.Drawing.Point(116, 377);
            this.DeleteId.Name = "DeleteId";
            this.DeleteId.Size = new System.Drawing.Size(100, 22);
            this.DeleteId.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 380);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "ID da conta :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 23);
            this.label11.TabIndex = 24;
            this.label11.Text = "Editar";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 33);
            this.button2.TabIndex = 25;
            this.button2.Text = "Atualizar conta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DeleteId);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.tipoF);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.usernameF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.senhaF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.especialidadeF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.telefoneF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nomeF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lista);
            this.Name = "AdminMenu";
            this.Text = "AdminMenu";
            this.Load += new System.EventHandler(this.AdminMenu_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nomeF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telefoneF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox especialidadeF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox senhaF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox usernameF;
        private System.Windows.Forms.ComboBox tipoF;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox DeleteId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}