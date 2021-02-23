using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Centro
    {
        private String _ID;
        private String _Nome;
        private String _Localizacao;
        private String _Num_lojas;
        private String _Area_total;

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

        public String Localizacao
        {
            get { return _Localizacao; }
            set { _Localizacao = value; }
        }

        public String Num_lojas
        {
            get { return _Num_lojas; }
            set { _Num_lojas = value; }
        }

        public String Area_total
        {
            get { return _Area_total; }
            set { _Area_total = value; }
        }

        public override String ToString()
        {
            return _Nome;
        }

    }
}
