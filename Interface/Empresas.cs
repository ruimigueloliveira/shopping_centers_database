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
    public partial class Empresas : UserControl
    {
        public Empresas()
        {
            InitializeComponent();
        }
        public void setTextNIF(String value)
        {
            textEmpresaNIF.Text = value;
        }
        public String getTextNIF()
        {
            return textEmpresaNIF.Text;
        }
        public void setTextNome(String value)
        {
            textEmpresaNome.Text = value;
        }
        public String getTextNome()
        {
            return textEmpresaNome.Text;
        }
        public void setTextContacto(String value)
        {
            textEmpresaContacto.Text = value;
        }
        public String getTextContacto()
        {
            return textEmpresaContacto.Text;
        }

        public void resetEmpresas()
        {
            setTextNIF("");
            setTextNome("");
            setTextContacto("");
            listBox1.Items.Clear();
        }

        public void readOnlyEmpresas()
        {
            textEmpresaNIF.ReadOnly = true;
            textEmpresaNome.ReadOnly = true;
            textEmpresaContacto.ReadOnly = true;
        }
        public void adicionarEmpresas()
        {
            textEmpresaNIF.ReadOnly = false;
            textEmpresaNome.ReadOnly = false;
            textEmpresaContacto.ReadOnly = false;
        }
        public void editarEmpresas()
        {
            textEmpresaNIF.ReadOnly = true;
            textEmpresaNome.ReadOnly = false;
            textEmpresaContacto.ReadOnly = false;
        }
        public void Search()
        {
            readOnlyEmpresas();
            textEmpresaNIF.ReadOnly = false;
        }
    }
}
