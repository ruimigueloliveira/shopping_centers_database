using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Loja
    {
        private String _Contacto;
        private String _Nome_comercial;
        private String _Renda;
        private String _Num_loja;
        private String _Tipo;
        private String _ID_centro;
        private String _Area;
        private Empresa _empresa;
        //private String _Nome_empresa;
        //private String _NIF_empresa;
        private String _Nome_gerente;
        private String _Num_gerente;

        public String Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }

        public String Nome_comercial
        {
            get { return _Nome_comercial; }
            set { _Nome_comercial = value; }
        }

        public String Renda
        {
            get { return _Renda; }
            set { _Renda = value; }
        }

        public String Num_loja
        {
            get { return _Num_loja; }
            set { _Num_loja = value; }
        }

        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public String ID_centro
        {
            get { return _ID_centro; }
            set { _ID_centro = value; }
        }

        public String Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        //public String Nome_empresa
        //{
        //    get { return _Nome_empresa; }
        //    set { _Nome_empresa = value; }
        //}

        //public String NIF_empresa
        //{
        //    get { return _NIF_empresa; }
        //    set { _NIF_empresa = value; }
        //}

        public String Nome_gerente
        {
            get { return _Nome_gerente; }
            set { _Nome_gerente = value; }
        }

        public String Num_gerente
        {
            get { return _Num_gerente; }
            set { _Num_gerente = value; }
        }

        public Empresa empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        public override String ToString()
        {
            return _Nome_comercial;
        }
    }
}
