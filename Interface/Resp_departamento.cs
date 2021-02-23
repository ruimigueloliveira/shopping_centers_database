using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Resp_departamento
    {
        private String _NIF;
        private String _Num_func;
        private String _Salario;
        private String _Habilitacoes;
        private String _Primeiro_nome;
        private String _Ultimo_nome;
        private String _Sexo;
        private String _Contacto;
        private String _Departamento;
        private String _ID_centro;

        public String NIF
        {
            get { return _NIF; }
            set { _NIF = value; }
        }
        public String Num_func
        {
            get { return _Num_func; }
            set { _Num_func = value; }
        }
        public String Salario
        {
            get { return _Salario; }
            set { _Salario = value; }
        }
        public String Habilitacoes
        {
            get { return _Habilitacoes; }
            set { _Habilitacoes = value; }
        }
        public String Primeiro_nome
        {
            get { return _Primeiro_nome; }
            set { _Primeiro_nome = value; }
        }
        public String Ultimo_nome
        {
            get { return _Ultimo_nome; }
            set { _Ultimo_nome = value; }
        }
        public String Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }
        public String Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public String Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }
        public String ID_centro
        {
            get { return _ID_centro; }
            set { _ID_centro = value; }
        }
        public override String ToString()
        {
            return _Num_func + " " + _Primeiro_nome + " " + _Ultimo_nome;
        }
    }
}
