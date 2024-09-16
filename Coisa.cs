using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    internal class Coisa
    {
        private int id;
        private string descricao;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public Coisa(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public Coisa(int id) : this(id, "")
        {
        }

        public Coisa() : this(0, "")
        {
        }

        public override string ToString()
        {
            return this.id.ToString() + " - " + this.descricao + '\n';
        }

        public override bool Equals(object obj)
        {
            return (this.Id == ((Coisa)obj).Id);
        }
    }
}
