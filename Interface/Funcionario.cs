using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Funcionario
    {
        private String _NIF;
        private String _Num_func;
        private String _Contacto;
        private String _Primeiro_nome;
        private String _Ultimo_nome;
        private String _Salario;
        private String _Horas_semanais;
        private String _Data_entrada;
        private String _Nome_loja;
        private String _Numero_loja;
        private String _Sexo;

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
        public String Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
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
        public String Salario
        {
            get { return _Salario; }
            set { _Salario = value; }
        }
        public String Horas_semanais
        {
            get { return _Horas_semanais; }
            set { _Horas_semanais = value; }
        }
        public String Data_entrada
        {
            get { return _Data_entrada; }
            set { _Data_entrada = value; }
        }
        public String Nome_loja
        {
            get { return _Nome_loja; }
            set { _Nome_loja = value; }
        }
        public String Numero_loja
        {
            get { return _Numero_loja; }
            set { _Numero_loja = value; }
        }
        public String Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }
        public override String ToString()
        {
            return _Num_func + " " + _Primeiro_nome + " " + _Ultimo_nome;
        }
    }
}
