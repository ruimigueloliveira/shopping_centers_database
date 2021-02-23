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
    public partial class Prestadores : UserControl
    {
        public Prestadores()
        {
            InitializeComponent();
        }

        public void setTextNIF(String value)
        {
            textPrestadorNIF.Text = value;
        }

        public void setTextServico(String value)
        {
            textPrestadorServico.Text = value;
        }
        public void setTextEmpresa(String value)
        {
            textPrestadorEmpresa.Text = value;
        }
        public void setTextHoras(String value)
        {
            if (value == "")
                textPrestadorHoras.Text = "NULL";
            else if (value == "NULL")
            {
                textPrestadorHoras.Text = "NULL";
            }
            else if (value == "0")
            {
                textPrestadorHoras.Text = "NULL";
            }
            else
                textPrestadorHoras.Text = value;
        }
        public void setTextCusto(String value)
        {
            textPrestadorCusto.Text = value;
        }
        public String getTextNIF()
        {
            if (textPrestadorNIF.Text == "") return null;
            return textPrestadorNIF.Text;
        }
        public String getTextServico()
        {
            if (textPrestadorServico.Text == "") return "NULL";
            return textPrestadorServico.Text;
        }
        public String getTextEmpresa()
        {
            if (textPrestadorEmpresa.Text == "") return "NULL";
            return textPrestadorEmpresa.Text;
        }
        public String getTextHoras()
        {
            if (textPrestadorHoras.Text.Equals("NULL"))
            {
                return "0";
            }
            else if (textPrestadorHoras.Text.Equals(""))
            {
                return "0";
            }
            return textPrestadorHoras.Text;
        }
        public String getTextCusto()
        {
            return textPrestadorCusto.Text;
        }
        public void resetPrestadores()
        {
            setTextNIF("");
            setTextServico("");
            setTextEmpresa("");
            setTextHoras(" ");
            setTextCusto("");
        }
        public void readOnlyPrestadores()
        {
            textPrestadorNIF.ReadOnly = true;
            textPrestadorServico.ReadOnly = true;
            textPrestadorEmpresa.ReadOnly = true;
            textPrestadorHoras.ReadOnly = true;
            textPrestadorCusto.ReadOnly = true;
        }
        public void editablePrestadores()
        {
            textPrestadorNIF.ReadOnly = false;
            textPrestadorServico.ReadOnly = false;
            textPrestadorEmpresa.ReadOnly = false;
            textPrestadorHoras.ReadOnly = false;
            textPrestadorCusto.ReadOnly = false;
        }
        public void editarPrestadores()
        {
            textPrestadorNIF.ReadOnly = true;
        }
        public void Search()
        {
            readOnlyPrestadores();
            textPrestadorNIF.ReadOnly = false;
        }
    }
}
