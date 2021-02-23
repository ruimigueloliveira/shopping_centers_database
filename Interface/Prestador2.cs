using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Prestador2
    {
        private String _NIF;
        private String _Empresa;
        private String _Horas_mensais;
        private String _Servico;
        private String _Custo_mensal;


        public String NIF
        {
            get { return _NIF; }
            set { _NIF = value; }
        }
        public String Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }
        public String Horas_mensais
        {
            get { return _Horas_mensais; }
            set { _Horas_mensais = value; }
        }
        public String Servico
        {
            get { return _Servico; }
            set { _Servico = value; }
        }
        public String Custo_mensal
        {
            get { return _Custo_mensal; }
            set { _Custo_mensal = value; }
        }
        public override String ToString()
        {
            return _Servico + " - " + _Empresa;
        }
    }
}
