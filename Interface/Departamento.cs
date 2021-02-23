using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Departamento
    {
        private String _ID;
        private String _Nome;
        private String _Nome_responsavel;
        private String _Num_responsavel;
        
        public Departamento(String id = null, String nome = null, String nomeResp = null, String numResp = null)
        {
            ID = id;
            Nome = nome;
            Nome_responsavel = nomeResp;
            Num_responsavel = numResp;
        }

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public String Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public String Nome_responsavel
        {
            get { return _Nome_responsavel; }
            set { _Nome_responsavel = value; }
        }
        public String Num_responsavel
        {
            get { return _Num_responsavel; }
            set { _Num_responsavel = value; }
        }
        
        public override String ToString()
        {
            return _Nome;
        }

            
    }
}
