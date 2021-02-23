namespace Interface
{
    partial class Eventos
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
            this.textEventoNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textEventoDepartamento = new System.Windows.Forms.TextBox();
            this.labelNomeDep = new System.Windows.Forms.Label();
            this.textEventoTipo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEventoFim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textEventoInicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textEventoNome
            // 
            this.textEventoNome.Location = new System.Drawing.Point(5, 22);
            this.textEventoNome.Name = "textEventoNome";
            this.textEventoNome.Size = new System.Drawing.Size(328, 22);
            this.textEventoNome.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Nome";
            // 
            // textEventoDepartamento
            // 
            this.textEventoDepartamento.Location = new System.Drawing.Point(179, 135);
            this.textEventoDepartamento.Name = "textEventoDepartamento";
            this.textEventoDepartamento.Size = new System.Drawing.Size(154, 22);
            this.textEventoDepartamento.TabIndex = 51;
            // 
            // labelNomeDep
            // 
            this.labelNomeDep.AutoSize = true;
            this.labelNomeDep.Location = new System.Drawing.Point(176, 115);
            this.labelNomeDep.Name = "labelNomeDep";
            this.labelNomeDep.Size = new System.Drawing.Size(98, 17);
            this.labelNomeDep.TabIndex = 50;
            this.labelNomeDep.Text = "Departamento";
            // 
            // textEventoTipo
            // 
            this.textEventoTipo.Location = new System.Drawing.Point(5, 135);
            this.textEventoTipo.Name = "textEventoTipo";
            this.textEventoTipo.Size = new System.Drawing.Size(154, 22);
            this.textEventoTipo.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Tipo";
            // 
            // textEventoFim
            // 
            this.textEventoFim.Location = new System.Drawing.Point(179, 81);
            this.textEventoFim.Name = "textEventoFim";
            this.textEventoFim.Size = new System.Drawing.Size(154, 22);
            this.textEventoFim.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Data de fim";
            // 
            // textEventoInicio
            // 
            this.textEventoInicio.Location = new System.Drawing.Point(5, 81);
            this.textEventoInicio.Name = "textEventoInicio";
            this.textEventoInicio.Size = new System.Drawing.Size(154, 22);
            this.textEventoInicio.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Data de inicio";
            // 
            // Eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEventoInicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textEventoFim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textEventoTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEventoNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textEventoDepartamento);
            this.Controls.Add(this.labelNomeDep);
            this.Location = new System.Drawing.Point(210, 0);
            this.Name = "Eventos";
            this.Size = new System.Drawing.Size(348, 168);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textEventoNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEventoDepartamento;
        private System.Windows.Forms.Label labelNomeDep;
        private System.Windows.Forms.TextBox textEventoTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEventoFim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textEventoInicio;
        private System.Windows.Forms.Label label5;
    }
}
