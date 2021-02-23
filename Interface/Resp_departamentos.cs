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
    public partial class Resp_departamentos : UserControl
    {
        private int numResp;
        public Resp_departamentos()
        {
            InitializeComponent();
        }
        public int getNumResp()
        {
            return numResp;
        }
        public void setNumResp(int value)
        {
            numResp = value;
        }
        public void updateNumResp()
        {
            numResp += 1;
        }
        public void setTextNIF(String value)
        {
            textResponsavelNIF.Text = value;
        }
        public void setTextNumeroFunc(String value)
        {
            textResponsavelNumeroFuncionario.Text = value;
        }
        public void setTextContacto(String value)
        {
            textResponsavelContacto.Text = value;
        }
        public void setTextPrimeiroNome(String value)
        {
            textResponsavelPrimeiroNome.Text = value;
        }
        public void setTextUltimoNome(String value)
        {
            textResponsavelUltimoNome.Text = value;
        }
        public void setTextSalario(String value)
        {
            textResponsavelSalario.Text = value;
        }
        public void setTextSexo(String value)
        {
            textResponsavelSexo.Text = value;
        }
        public void setTextHabilitacoes(String value)
        {
            textResponsavelHabilitacoes.Text = value;
        }
        public void setTextDepartamento(String value)
        {
            textResponsavelDepartamento.Text = value;
        }
        public String getTextNIF()
        {
            return textResponsavelNIF.Text;
        }
        public String getTextNumeroFunc()
        {
            return textResponsavelNumeroFuncionario.Text;
        }
        public String getTextContacto()
        {
            return textResponsavelContacto.Text;
        }
        public String getTextPrimeiroNome()
        {
            if (textResponsavelPrimeiroNome.Text == "") return "NULL";
            return textResponsavelPrimeiroNome.Text;
        }
        public String getTextUltimoNome()
        {
            if (textResponsavelUltimoNome.Text == "") return "NULL";
            return textResponsavelUltimoNome.Text;
        }
        public String getTextSalario()
        {
            if (textResponsavelSalario.Text == "") return "1801";

            int salario = Int32.Parse(textResponsavelSalario.Text);
            if (salario < 1801) return "1801";
            if (salario > 2499) return "2499";


            return textResponsavelSalario.Text;
        }
        public String getTextSexo()
        {
            return textResponsavelSexo.Text;
        }
        public String getTextHabilitacoes()
        {
            return textResponsavelHabilitacoes.Text;
        }
        public String getTextDepartamento()
        {
            return textResponsavelDepartamento.Text;
        }
        public void resetResponsavel()
        {
            setTextNIF("");
            setTextNumeroFunc("");
            setTextContacto("");
            setTextPrimeiroNome("");
            setTextUltimoNome("");
            setTextSalario("");
            setTextSexo("");
            setTextDepartamento("");
            setTextHabilitacoes("");
        }
        public void readOnlyResponsavel()
        {
            textResponsavelNIF.ReadOnly = true;
            textResponsavelNumeroFuncionario.ReadOnly = true;
            textResponsavelContacto.ReadOnly = true;
            textResponsavelPrimeiroNome.ReadOnly = true;
            textResponsavelUltimoNome.ReadOnly = true;
            textResponsavelSalario.ReadOnly = true;
            textResponsavelSexo.ReadOnly = true;
            textResponsavelDepartamento.ReadOnly = true;
            textResponsavelHabilitacoes.ReadOnly = true;
        }
        public void editableResponsavel()
        {
            textResponsavelNIF.ReadOnly = false;
            textResponsavelNumeroFuncionario.ReadOnly = false;
            textResponsavelContacto.ReadOnly = false;
            textResponsavelPrimeiroNome.ReadOnly = false;
            textResponsavelUltimoNome.ReadOnly = false;
            textResponsavelSalario.ReadOnly = false;
            textResponsavelSexo.ReadOnly = false;
            textResponsavelDepartamento.ReadOnly = false;
            textResponsavelHabilitacoes.ReadOnly = false;
        }
        public void adicionarResponsavel()
        {
            textResponsavelDepartamento.ReadOnly = true;
            textResponsavelNumeroFuncionario.ReadOnly = true;
            setTextNumeroFunc(getNumResp().ToString());
        }
        public void editarResponsavel()
        {
            textResponsavelDepartamento.ReadOnly = true;
            textResponsavelNIF.ReadOnly = true;
            textResponsavelNumeroFuncionario.ReadOnly = true;
        }
        public void cancelConfirmResponsavel()
        {
            textResponsavelDepartamento.Visible = true;
            label2.Visible = true;
        }
        public void Search()
        {
            readOnlyResponsavel();
            textResponsavelNIF.ReadOnly = false;
        }

    }
}
