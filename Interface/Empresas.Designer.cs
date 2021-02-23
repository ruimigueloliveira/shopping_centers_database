namespace Interface
{
    partial class Empresas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textEmpresaNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textEmpresaContacto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmpresaNIF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textEmpresaNome
            // 
            this.textEmpresaNome.Location = new System.Drawing.Point(6, 25);
            this.textEmpresaNome.Name = "textEmpresaNome";
            this.textEmpresaNome.Size = new System.Drawing.Size(225, 22);
            this.textEmpresaNome.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Nome";
            // 
            // textEmpresaContacto
            // 
            this.textEmpresaContacto.Location = new System.Drawing.Point(6, 130);
            this.textEmpresaContacto.Name = "textEmpresaContacto";
            this.textEmpresaContacto.Size = new System.Drawing.Size(225, 22);
            this.textEmpresaContacto.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Contacto";
            // 
            // textEmpresaNIF
            // 
            this.textEmpresaNIF.Location = new System.Drawing.Point(6, 78);
            this.textEmpresaNIF.Name = "textEmpresaNIF";
            this.textEmpresaNIF.Size = new System.Drawing.Size(225, 22);
            this.textEmpresaNIF.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "NIF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "Lojas";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(257, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 132);
            this.listBox1.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(568, 17);
            this.label5.TabIndex = 87;
            this.label5.Text = "Se pretender acrescentar uma loja a uma empresa, por favor selecione o botão \"LOJ" +
    "AS\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(663, 17);
            this.label6.TabIndex = 88;
            this.label6.Text = "ATENÇÃO: Ao remover uma empresa eliminará as suas lojas e consequentemente os seu" +
    "s funcionários";
            // 
            // Empresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textEmpresaNIF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEmpresaContacto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEmpresaNome);
            this.Controls.Add(this.label1);
            this.Name = "Empresas";
            this.Size = new System.Drawing.Size(686, 259);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textEmpresaNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEmpresaContacto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEmpresaNIF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
