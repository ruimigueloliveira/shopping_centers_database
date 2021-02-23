namespace Interface
{
    partial class Prestadores
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
            this.textPrestadorEmpresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPrestadorHoras = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPrestadorServico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrestadorNIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textPrestadorCusto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textPrestadorEmpresa
            // 
            this.textPrestadorEmpresa.Location = new System.Drawing.Point(7, 84);
            this.textPrestadorEmpresa.Name = "textPrestadorEmpresa";
            this.textPrestadorEmpresa.Size = new System.Drawing.Size(300, 22);
            this.textPrestadorEmpresa.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 52;
            this.label5.Text = "Empresa prestadora";
            // 
            // textPrestadorHoras
            // 
            this.textPrestadorHoras.Location = new System.Drawing.Point(7, 143);
            this.textPrestadorHoras.Name = "textPrestadorHoras";
            this.textPrestadorHoras.Size = new System.Drawing.Size(134, 22);
            this.textPrestadorHoras.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "Horas mensais";
            // 
            // textPrestadorServico
            // 
            this.textPrestadorServico.Location = new System.Drawing.Point(170, 24);
            this.textPrestadorServico.Name = "textPrestadorServico";
            this.textPrestadorServico.Size = new System.Drawing.Size(137, 22);
            this.textPrestadorServico.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Serviço";
            // 
            // textPrestadorNIF
            // 
            this.textPrestadorNIF.Location = new System.Drawing.Point(7, 24);
            this.textPrestadorNIF.Name = "textPrestadorNIF";
            this.textPrestadorNIF.Size = new System.Drawing.Size(134, 22);
            this.textPrestadorNIF.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "NIF";
            // 
            // textPrestadorCusto
            // 
            this.textPrestadorCusto.Location = new System.Drawing.Point(170, 143);
            this.textPrestadorCusto.Name = "textPrestadorCusto";
            this.textPrestadorCusto.Size = new System.Drawing.Size(137, 22);
            this.textPrestadorCusto.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Custo mensal (€)";
            // 
            // Prestadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textPrestadorCusto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPrestadorEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textPrestadorHoras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textPrestadorServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPrestadorNIF);
            this.Controls.Add(this.label1);
            this.Name = "Prestadores";
            this.Size = new System.Drawing.Size(327, 187);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPrestadorEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPrestadorHoras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPrestadorServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrestadorNIF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPrestadorCusto;
        private System.Windows.Forms.Label label4;
    }
}
