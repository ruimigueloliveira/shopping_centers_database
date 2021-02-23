namespace Interface
{
    partial class Departamentos
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
            this.textDeparatmentoNome_responsavel = new System.Windows.Forms.TextBox();
            this.labelNomeResp = new System.Windows.Forms.Label();
            this.textDeparatmentoNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textDeparatmentoID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDepartamentosAdministradores = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textDeparatmentoNome_responsavel
            // 
            this.textDeparatmentoNome_responsavel.Location = new System.Drawing.Point(6, 79);
            this.textDeparatmentoNome_responsavel.Name = "textDeparatmentoNome_responsavel";
            this.textDeparatmentoNome_responsavel.Size = new System.Drawing.Size(150, 22);
            this.textDeparatmentoNome_responsavel.TabIndex = 45;
            // 
            // labelNomeResp
            // 
            this.labelNomeResp.AutoSize = true;
            this.labelNomeResp.Location = new System.Drawing.Point(3, 57);
            this.labelNomeResp.Name = "labelNomeResp";
            this.labelNomeResp.Size = new System.Drawing.Size(95, 17);
            this.labelNomeResp.TabIndex = 44;
            this.labelNomeResp.Text = "Administrador";
            // 
            // textDeparatmentoNome
            // 
            this.textDeparatmentoNome.Location = new System.Drawing.Point(3, 22);
            this.textDeparatmentoNome.Name = "textDeparatmentoNome";
            this.textDeparatmentoNome.Size = new System.Drawing.Size(150, 22);
            this.textDeparatmentoNome.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Departamento";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(527, 108);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 17);
            this.labelID.TabIndex = 36;
            this.labelID.Text = "ID";
            this.labelID.Visible = false;
            // 
            // textDeparatmentoID
            // 
            this.textDeparatmentoID.Location = new System.Drawing.Point(530, 128);
            this.textDeparatmentoID.Name = "textDeparatmentoID";
            this.textDeparatmentoID.Size = new System.Drawing.Size(118, 22);
            this.textDeparatmentoID.TabIndex = 37;
            this.textDeparatmentoID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 17);
            this.label4.TabIndex = 93;
            this.label4.Text = "O departamento Comercial é responsável pelas Empresas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(397, 17);
            this.label3.TabIndex = 92;
            this.label3.Text = "O departamento Operações é responsável pelos Prestadores";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(363, 17);
            this.label5.TabIndex = 91;
            this.label5.Text = "O departamento Marketing é responsável pelos Eventos";
            // 
            // comboBoxDepartamentosAdministradores
            // 
            this.comboBoxDepartamentosAdministradores.FormattingEnabled = true;
            this.comboBoxDepartamentosAdministradores.Location = new System.Drawing.Point(6, 77);
            this.comboBoxDepartamentosAdministradores.Name = "comboBoxDepartamentosAdministradores";
            this.comboBoxDepartamentosAdministradores.Size = new System.Drawing.Size(150, 24);
            this.comboBoxDepartamentosAdministradores.TabIndex = 94;
            this.comboBoxDepartamentosAdministradores.Visible = false;
            // 
            // Departamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxDepartamentosAdministradores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textDeparatmentoNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDeparatmentoID);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textDeparatmentoNome_responsavel);
            this.Controls.Add(this.labelNomeResp);
            this.Name = "Departamentos";
            this.Size = new System.Drawing.Size(416, 241);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textDeparatmentoNome_responsavel;
        private System.Windows.Forms.Label labelNomeResp;
        private System.Windows.Forms.TextBox textDeparatmentoNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textDeparatmentoID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBoxDepartamentosAdministradores;
    }
}
