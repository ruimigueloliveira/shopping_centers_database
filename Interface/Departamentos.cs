using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Departamentos : UserControl
    {
        private int numDep;
        public Departamentos()
        {
            InitializeComponent();
        }
        public int getNumDep()
        {
            return numDep;
        }
        public void setNumDep(int value)
        {
            numDep = value;
        }
        public void setTextID(String value)
        {
            textDeparatmentoID.Text = value;
        }
        public void setTextNome(String value)
        {
            textDeparatmentoNome.Text = value;
        }
        public void setTextNome_responsavel(String value)
        {
            textDeparatmentoNome_responsavel.Text = value;
        }
        public void setComboBoxNome_responsavel(String value)
        {
            comboBoxDepartamentosAdministradores.Text = value;
        }
        public String getTextID()
        {
            return textDeparatmentoID.Text;
        }
        public String getTextNome()
        {
            return textDeparatmentoNome.Text;
        }
        public String getTextNome_responsavel()
        {
            string fullStr = comboBoxDepartamentosAdministradores.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[1];
        }
        public String getTextNum_responsavel()
        {
            string fullStr = comboBoxDepartamentosAdministradores.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[0];
        }
        public void resetDepartamentos()
        {
            setTextID("");
            setTextNome("");
            setTextNome_responsavel("");
        }
        public void readOnlyDepartamentos()
        {
            textDeparatmentoID.ReadOnly = true;
            textDeparatmentoNome.ReadOnly = true;
            textDeparatmentoNome_responsavel.ReadOnly = true;
            labelNomeResp.Visible = true;
            textDeparatmentoNome_responsavel.Visible = true;
            comboBoxDepartamentosAdministradores.Visible = false;
        }
        public void editableDepartamentos()
        {
            textDeparatmentoID.ReadOnly = false;
            textDeparatmentoNome.ReadOnly = false;
            textDeparatmentoNome_responsavel.ReadOnly = false;
        }
        public void adicionarDepartamento()
        {
            textDeparatmentoNome_responsavel.Visible = false;
            comboBoxDepartamentosAdministradores.Visible = true;
            labelNomeResp.Visible = true;
            textDeparatmentoID.ReadOnly = true;
            comboBoxDepartamentosAdministradores.Text = "";
        }
        public void editarDepartamento()
        {
            textDeparatmentoNome_responsavel.Visible = false;
            comboBoxDepartamentosAdministradores.Visible = true;
            labelNomeResp.Visible = true;
            textDeparatmentoID.ReadOnly = true;
        }
        public void cancelConfirmDepartamento()
        {
            readOnlyDepartamentos();
        }
        public void Search()
        {
            readOnlyDepartamentos();
            textDeparatmentoID.ReadOnly = false;
        }
    }
}
