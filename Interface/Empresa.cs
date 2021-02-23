using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Empresa
    {
        private String _NIF;
        private String _Nome;
        private String _Contacto;

        public Empresa (string nif=null, string nome=null)
        {
            NIF = nif;
            Nome = nome;
        }

        public String NIF
        {
            get { return _NIF; }
            set { _NIF = value; }
        }
        public String Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public String Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public override String ToString()
        {
            return _Nome;
        }
    }
}
