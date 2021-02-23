namespace Interface
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.textCentroNumeroLojas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCentroLocalizacao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textCentroArea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCentroNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textCentroID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listBox8 = new System.Windows.Forms.ListBox();
            this.btnAddCentro = new System.Windows.Forms.Button();
            this.btnEditCentro = new System.Windows.Forms.Button();
            this.btnRemoveCentro = new System.Windows.Forms.Button();
            this.btnConfirmCentro = new System.Windows.Forms.Button();
            this.btnCancelarCentro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.departamentos1 = new Interface.Departamentos();
            this.prestadores1 = new Interface.Prestadores();
            this.eventos1 = new Interface.Eventos();
            this.empresas1 = new Interface.Empresas();
            this.resp_departamentos1 = new Interface.Resp_departamentos();
            this.lojas1 = new Interface.Lojas();
            this.funcionarios1 = new Interface.Funcionarios();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // textCentroNumeroLojas
            // 
            resources.ApplyResources(this.textCentroNumeroLojas, "textCentroNumeroLojas");
            this.textCentroNumeroLojas.Name = "textCentroNumeroLojas";
            this.textCentroNumeroLojas.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textCentroLocalizacao
            // 
            resources.ApplyResources(this.textCentroLocalizacao, "textCentroLocalizacao");
            this.textCentroLocalizacao.Name = "textCentroLocalizacao";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textCentroArea
            // 
            resources.ApplyResources(this.textCentroArea, "textCentroArea");
            this.textCentroArea.Name = "textCentroArea";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textCentroNome
            // 
            resources.ApplyResources(this.textCentroNome, "textCentroNome");
            this.textCentroNome.Name = "textCentroNome";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textCentroID
            // 
            resources.ApplyResources(this.textCentroID, "textCentroID");
            this.textCentroID.Name = "textCentroID";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            resources.ApplyResources(this.listBox2, "listBox2");
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            resources.ApplyResources(this.listBox3, "listBox3");
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            resources.ApplyResources(this.listBox4, "listBox4");
            this.listBox4.Name = "listBox4";
            this.listBox4.SelectedIndexChanged += new System.EventHandler(this.listBox4_SelectedIndexChanged);
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            resources.ApplyResources(this.listBox6, "listBox6");
            this.listBox6.Name = "listBox6";
            this.listBox6.SelectedIndexChanged += new System.EventHandler(this.listBox6_SelectedIndexChanged);
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            resources.ApplyResources(this.listBox5, "listBox5");
            this.listBox5.Name = "listBox5";
            this.listBox5.SelectedIndexChanged += new System.EventHandler(this.listBox5_SelectedIndexChanged);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            resources.ApplyResources(this.listBox7, "listBox7");
            this.listBox7.Name = "listBox7";
            this.listBox7.SelectedIndexChanged += new System.EventHandler(this.listBox7_SelectedIndexChanged_1);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listBox8
            // 
            this.listBox8.FormattingEnabled = true;
            resources.ApplyResources(this.listBox8, "listBox8");
            this.listBox8.Name = "listBox8";
            this.listBox8.SelectedIndexChanged += new System.EventHandler(this.listBox8_SelectedIndexChanged);
            // 
            // btnAddCentro
            // 
            resources.ApplyResources(this.btnAddCentro, "btnAddCentro");
            this.btnAddCentro.Name = "btnAddCentro";
            this.btnAddCentro.UseVisualStyleBackColor = true;
            this.btnAddCentro.Click += new System.EventHandler(this.btnAddCentro_Click);
            // 
            // btnEditCentro
            // 
            resources.ApplyResources(this.btnEditCentro, "btnEditCentro");
            this.btnEditCentro.Name = "btnEditCentro";
            this.btnEditCentro.UseVisualStyleBackColor = true;
            this.btnEditCentro.Click += new System.EventHandler(this.btnEditCentro_Click);
            // 
            // btnRemoveCentro
            // 
            resources.ApplyResources(this.btnRemoveCentro, "btnRemoveCentro");
            this.btnRemoveCentro.Name = "btnRemoveCentro";
            this.btnRemoveCentro.UseVisualStyleBackColor = true;
            this.btnRemoveCentro.Click += new System.EventHandler(this.btnRemoveCentro_Click);
            // 
            // btnConfirmCentro
            // 
            resources.ApplyResources(this.btnConfirmCentro, "btnConfirmCentro");
            this.btnConfirmCentro.Name = "btnConfirmCentro";
            this.btnConfirmCentro.UseVisualStyleBackColor = true;
            this.btnConfirmCentro.Click += new System.EventHandler(this.btnConfirmCentro_Click);
            // 
            // btnCancelarCentro
            // 
            resources.ApplyResources(this.btnCancelarCentro, "btnCancelarCentro");
            this.btnCancelarCentro.Name = "btnCancelarCentro";
            this.btnCancelarCentro.UseVisualStyleBackColor = true;
            this.btnCancelarCentro.Click += new System.EventHandler(this.btnCancelarCentro_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // departamentos1
            // 
            resources.ApplyResources(this.departamentos1, "departamentos1");
            this.departamentos1.Name = "departamentos1";
            // 
            // prestadores1
            // 
            resources.ApplyResources(this.prestadores1, "prestadores1");
            this.prestadores1.Name = "prestadores1";
            // 
            // eventos1
            // 
            resources.ApplyResources(this.eventos1, "eventos1");
            this.eventos1.Name = "eventos1";
            // 
            // empresas1
            // 
            resources.ApplyResources(this.empresas1, "empresas1");
            this.empresas1.Name = "empresas1";
            // 
            // resp_departamentos1
            // 
            resources.ApplyResources(this.resp_departamentos1, "resp_departamentos1");
            this.resp_departamentos1.Name = "resp_departamentos1";
            // 
            // lojas1
            // 
            resources.ApplyResources(this.lojas1, "lojas1");
            this.lojas1.Name = "lojas1";
            // 
            // funcionarios1
            // 
            resources.ApplyResources(this.funcionarios1, "funcionarios1");
            this.funcionarios1.Name = "funcionarios1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelarCentro);
            this.Controls.Add(this.btnConfirmCentro);
            this.Controls.Add(this.btnRemoveCentro);
            this.Controls.Add(this.btnEditCentro);
            this.Controls.Add(this.btnAddCentro);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textCentroNumeroLojas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textCentroLocalizacao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textCentroArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textCentroNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textCentroID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.listBox6);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox8);
            this.Controls.Add(this.listBox7);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.departamentos1);
            this.Controls.Add(this.prestadores1);
            this.Controls.Add(this.eventos1);
            this.Controls.Add(this.empresas1);
            this.Controls.Add(this.resp_departamentos1);
            this.Controls.Add(this.lojas1);
            this.Controls.Add(this.funcionarios1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.TextBox textCentroNumeroLojas;
        public System.Windows.Forms.TextBox textCentroLocalizacao;
        public System.Windows.Forms.TextBox textCentroArea;
        public System.Windows.Forms.TextBox textCentroNome;
        public System.Windows.Forms.TextBox textCentroID;
        public System.Windows.Forms.ListBox listBox2;
        public System.Windows.Forms.ListBox listBox3;
        public System.Windows.Forms.ListBox listBox4;
        public System.Windows.Forms.ListBox listBox6;
        public System.Windows.Forms.ListBox listBox5;
        public System.Windows.Forms.ListBox listBox7;
        public System.Windows.Forms.Button button6;
        public Prestadores prestadores1;
        public Lojas lojas1;
        public Funcionarios funcionarios1;
        public Eventos eventos1;
        public Empresas empresas1;
        public Departamentos departamentos1;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button btnSearch;
        public Resp_departamentos resp_departamentos1;
        public System.Windows.Forms.ListBox listBox8;
        public System.Windows.Forms.Button btnRemoveCentro;
        public System.Windows.Forms.Button btnEditCentro;
        public System.Windows.Forms.Button btnAddCentro;
        public System.Windows.Forms.Button btnCancelarCentro;
        public System.Windows.Forms.Button btnConfirmCentro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

