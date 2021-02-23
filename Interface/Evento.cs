using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Evento
    {
        private String _Tipo;
        private String _Data_inicio;
        private String _Data_fim;
        private String _Nome;
        private String _NomeDepartamento;
        private String _ID_Departamento;

        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        public String Data_inicio
        {
            get { return _Data_inicio; }
            set { _Data_inicio = value; }
        }
        public String Data_fim
        {
            get { return _Data_fim; }
            set { _Data_fim = value; }
        }
        public String Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public String NomeDepartamento
        {
            get { return _NomeDepartamento; }
            set { _NomeDepartamento = value; }
        }
        public String ID_Departamento
        {
            get { return _ID_Departamento; }
            set { _ID_Departamento = value; }
        }

        public override String ToString()
        {
            return _Nome;
        }
    }
}
