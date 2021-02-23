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
    public partial class Funcionarios : UserControl
    {
        private int numFuncionario;

        public Funcionarios()
        {
            InitializeComponent();
        }

        public int getNumFunc()
        {
            return numFuncionario;
        }
        public void setNumFunc(int value)
        {
            numFuncionario = value;
        }
        public void updateNumFunc()
        {
            numFuncionario += 1;
        }
        public void setTextNIF(String value)
        {
            textFuncionarioNIF.Text = value;
        }
        public void setTextNumeroFunc(String value)
        {
            textFuncionarioNumeroFuncionario.Text = value;
        }
        public void setTextContacto(String value)
        {
            textFuncionarioContacto.Text = value;
        }
        public void setTextHorasSemanais(String value)
        {
            textFuncionarioHorasSemanais.Text = value;
        }
        public void setTextDataEntrada(String value)
        {
            textFuncionarioDataEntrada.Text = value;
        }
        public void setTextNomeLoja(String value)
        {
            textFuncionarioNomeLoja.Text = value;
        }
        public void setTextNumLoja(String value)
        {
            comboBoxLojas.Text = value;
        }
        public String getTextNumLoja()
        {
            string fullStr = comboBoxLojas.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[0];
        }
        public void setTextPrimeiroNome(String value)
        {
            textFuncionarioPrimeiroNome.Text = value;
        }
        public void setTextUltimoNome(String value)
        {
            textFuncionarioUltimoNome.Text = value;
        }
        public void setTextSalario(String value)
        {
            textFuncionarioSalario.Text = value;
        }
        public void setTextSexo(String value)
        {
            textFuncionarioSexo.Text = value;
        }
        public String getTextNIF()
        {
            if (textFuncionarioNIF.Text == "") return null;
            return textFuncionarioNIF.Text;
        }
        public String getTextNumeroFunc()
        {
            return textFuncionarioNumeroFuncionario.Text;
        }
        public String getTextContacto()
        {
            return textFuncionarioContacto.Text;
        }
        public String getTextHorasSemanais()
        {
            return textFuncionarioHorasSemanais.Text;
        }
        public String getTextDataEntrada()
        {
            if (textFuncionarioDataEntrada.Text == "")
                return DateTime.Today.Day + " " + DateTime.Today.Month + " " + DateTime.Today.Year;
            return textFuncionarioDataEntrada.Text;
        }
        public String getTextNomeLoja()
        {
            string fullStr = comboBoxLojas.SelectedItem.ToString();
            string[] splt = fullStr.Split(' ');
            return splt[1];
        }
        public String getTextPrimeiroNome()
        {
            if (textFuncionarioPrimeiroNome.Text == "") return "NULL";
            return textFuncionarioPrimeiroNome.Text;
        }
        public String getTextUltimoNome()
        {
            if (textFuncionarioUltimoNome.Text == "") return "NULL";
            return textFuncionarioUltimoNome.Text;
        }
        public String getTextSalario()
        {
            if (textFuncionarioSalario.Text == "") return "801"; 

            int salario = Int32.Parse(textFuncionarioSalario.Text);
            if (salario < 801) return "801";
            if (salario > 1799) return "1799";


            return textFuncionarioSalario.Text;
        }
        public String getTextSexo()
        {
            return textFuncionarioSexo.Text;
        }
        public void resetFuncionarios()
        {
            setTextNIF("");
            setTextNumeroFunc("");
            setTextContacto("");
            setTextHorasSemanais(" ");
            setTextDataEntrada("");
            setTextNomeLoja("");
            setTextPrimeiroNome("");
            setTextUltimoNome("");
            setTextSalario("");
            setTextSexo("");
            setTextNumLoja("");
        }
        public void readOnlyFuncionarios()
        {
            textFuncionarioNIF.ReadOnly = true;
            textFuncionarioNumeroFuncionario.ReadOnly = true;
            textFuncionarioContacto.ReadOnly = true;
            textFuncionarioHorasSemanais.ReadOnly = true;
            textFuncionarioDataEntrada.ReadOnly = true;
            textFuncionarioNomeLoja.ReadOnly = true;
            textFuncionarioPrimeiroNome.ReadOnly = true;
            textFuncionarioUltimoNome.ReadOnly = true;
            textFuncionarioSalario.ReadOnly = true;
            textFuncionarioSexo.ReadOnly = true;
            comboBoxLojas.Visible = false;
        }
        public void editableFuncionarios()
        {
            textFuncionarioNIF.ReadOnly = false;
            textFuncionarioNumeroFuncionario.ReadOnly = false;
            textFuncionarioContacto.ReadOnly = false;
            textFuncionarioHorasSemanais.ReadOnly = false;
            textFuncionarioDataEntrada.ReadOnly = false;
            textFuncionarioPrimeiroNome.ReadOnly = false;
            textFuncionarioUltimoNome.ReadOnly = false;
            textFuncionarioSalario.ReadOnly = false;
            textFuncionarioSexo.ReadOnly = false;
        }
        public void adicionarFuncionario()
        {
            textFuncionarioNomeLoja.Visible = false;
            textFuncionarioNumeroFuncionario.ReadOnly = true;
            setTextNumeroFunc(getNumFunc().ToString());
            comboBoxLojas.Visible = true;
            comboBoxLojas.Text = "";
        }
        public void editarFuncionario()
        {
            textFuncionarioNomeLoja.Visible = false;
            comboBoxLojas.Visible = true;
            textFuncionarioNIF.ReadOnly = true;
            textFuncionarioNumeroFuncionario.ReadOnly = true;
        }
        public void cancelConfirmFuncionario()
        {
            readOnlyFuncionarios();
            textFuncionarioNomeLoja.Visible = true;
        }
        public void Search()
        {
            readOnlyFuncionarios();
            textFuncionarioPrimeiroNome.ReadOnly = false;
        }
    }
}
