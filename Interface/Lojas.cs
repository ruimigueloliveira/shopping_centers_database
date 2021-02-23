using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Interface
{
    public partial class Lojas : UserControl
    {
        private int numLoja;
        public Lojas()
        {
            InitializeComponent();
        }
        public int getNumLoja()
        {
            return numLoja;
        }
        public void setNumLoja(int value)
        {
            numLoja = value;
        }
        public void setTextContacto(String value)
        {
            textLojaContacto.Text = value;
        }
        public String getTextContacto()
        {
            return textLojaContacto.Text;
        }
        public void setTextNome_comercial(String value)
        {
            textLojaNome.Text = value;
        }
        public String getTextNome()
        {
            return textLojaNome.Text;
        }
        public void setTextRenda(String value)
        {
            textLojaRenda.Text = value;
        }
        public String getTextRenda()
        {
            return textLojaRenda.Text;
        }
        public void setTextNumLoja(String value)
        {
            textLojaNumLoja.Text = value;
        }
        public String getTextNumLoja()
        {
            return textLojaNumLoja.Text;
        }
        public void setTextTipo(String value)
        {
            textLojaTipo.Text = value;
        }
        public String getTextTipo()
        {
            return textLojaTipo.Text;
        }
        public void setTextNomeEmpresa(String value)
        {
            textLojaNomeEmpresa.Text = value;
        }
        public String getTextNomeEmpresa()
        {
            string fullStr = comboBoxEmpresas.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[1];
        }

        public void setTextNIFEmpresa(String value)
        {
            comboBoxEmpresas.Text = value;
        }
        public String getTextNIFEmpresa()
        {
            string fullStr = comboBoxEmpresas.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[0];
        }
        public void setTextArea(String value)
        {
            textLojaArea.Text = value;
        }
        public String getTextArea()
        {
            return textLojaArea.Text;
        }
        public void setTextNomeGerente(String value)
        {
            textLojaNomeGerente.Text = value;
        }
        public void setTextNumeroGerente(String value)
        {
            textLojaNumeroGerente.Text = value;
        }
        public String getTextNumGerente()
        {
            return textLojaNumeroGerente.Text;
        }


        public void resetLojas()
        {
            setTextContacto("");
            setTextNome_comercial("");
            setTextRenda("");
            setTextNumLoja("");
            setTextNomeEmpresa("");
            setTextTipo("");
            setTextArea("");
            setTextNomeGerente("");
            setTextNumeroGerente("");
            listBox1.Items.Clear();
        }
        public void readOnlyLojas()
        {
            textLojaContacto.ReadOnly = true;
            textLojaNome.ReadOnly = true;
            textLojaRenda.ReadOnly = true;
            textLojaNumLoja.ReadOnly = true;
            textLojaTipo.ReadOnly = true;
            textLojaNomeEmpresa.ReadOnly = true;
            textLojaArea.ReadOnly = true;
            textLojaNomeGerente.ReadOnly = true;
            textLojaNumeroGerente.ReadOnly = true;
        }
        public void editableLojas()
        {
            textLojaContacto.ReadOnly = false;
            textLojaNome.ReadOnly = false;
            textLojaRenda.ReadOnly = false;
            textLojaNumLoja.ReadOnly = false;
            textLojaTipo.ReadOnly = false;
            textLojaNomeEmpresa.ReadOnly = false;
            textLojaArea.ReadOnly = false;
            textLojaNumeroGerente.ReadOnly = false;
        }
        public void adicionarLoja()
        {
            textLojaNomeEmpresa.Visible = false;
            comboBoxEmpresas.Visible = true;
            textLojaNomeGerente.Visible = true;
            labelNomeGerente.Visible = true;
            textLojaNomeGerente.ReadOnly = true;
            textLojaNumeroGerente.Visible = true;
            textLojaNumeroGerente.ReadOnly = true;
            labelNumeroGerente.Visible = true;
            textLojaNumLoja.ReadOnly = true;
        }
        public void editarLoja()
        {
            textLojaNomeEmpresa.Visible = false;
            textLojaNumLoja.ReadOnly = true;
            textLojaNomeGerente.ReadOnly = true;
            labelNomeGerente.Visible = true;
            comboBoxEmpresas.Visible = true;
        }
        public void cancelConfirmLoja()
        {
            // Empresa
            comboBoxEmpresas.Visible = false;
            textLojaNomeEmpresa.Visible = true;
            textLojaNomeGerente.Visible = true;
            labelNomeGerente.Visible = true;
        }
        public void Search()
        {
            readOnlyLojas();
            textLojaNumLoja.ReadOnly = false;
        }
    }
}