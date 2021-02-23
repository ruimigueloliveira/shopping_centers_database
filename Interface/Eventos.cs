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
    public partial class Eventos : UserControl
    {
        public Eventos()
        {
            InitializeComponent();
        }
        public String getTipo() { return textEventoTipo.Text; }
        public String getNome()
        {
            if (textEventoNome.Text == "") return null;
            return textEventoNome.Text;
        }
        public String getInicio()
        {
            if (textEventoInicio.Text == "")
                return DateTime.Today.Day + " " + DateTime.Today.Month + " " + DateTime.Today.Year;
            return textEventoInicio.Text;
        }
        public String getFim()
        {
            if (textEventoFim.Text == "")
                return DateTime.Today.Day + " " + DateTime.Today.Month + " " + DateTime.Today.Year;
            return textEventoFim.Text;
        }

        public String getNomeDepartamento()
        {
            return "Marketing";
        }

        public String getID_Departamento(String idCentro)
        {
            return idCentro + "1";
        }

        public void setTextTipo(String value)
        {
            textEventoTipo.Text = value;
        }
        public void setTextNome(String value)
        {
            textEventoNome.Text = value;
        }
        public void setTextDepartamento(String value)
        {
            textEventoDepartamento.Text = value;
        }

        public void setTextInicio(String value)
        {
            textEventoInicio.Text = value;
        }
        public void setTextFim(String value)
        {
            textEventoFim.Text = value;
        }

        public void resetEventos()
        {
            setTextTipo("");
            setTextNome("");
            setTextDepartamento("");
            setTextInicio("");
            setTextFim("");
        }
        public void readOnlyEventos()
        {
            textEventoTipo.ReadOnly = true;
            textEventoNome.ReadOnly = true;
            textEventoDepartamento.ReadOnly = true;
            textEventoInicio.ReadOnly = true;
            textEventoFim.ReadOnly = true;
        }
        public void editableEventos()
        {
            textEventoTipo.ReadOnly = false;
            textEventoNome.ReadOnly = false;
            textEventoDepartamento.ReadOnly = false;
            textEventoInicio.ReadOnly = false;
            textEventoFim.ReadOnly = false;
        }
        public void adicionarEvento()
        {
            textEventoDepartamento.Visible = true;
            textEventoDepartamento.Text = "Marketing";
            textEventoDepartamento.ReadOnly = true;
            labelNomeDep.Visible = true;
        }
        public void editarEvento()
        {
            textEventoDepartamento.Visible = true;
            textEventoDepartamento.Text = "Marketing";
            textEventoDepartamento.ReadOnly = true;
            labelNomeDep.Visible = true;
            textEventoNome.ReadOnly = true;
        }
        public void cancelConfirmEvento()
        {
            textEventoDepartamento.Visible = true;
            labelNomeDep.Visible = true;
        }
        public void Search()
        {
            readOnlyEventos();
            textEventoNome.ReadOnly = false;
        }
    }
}
