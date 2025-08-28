using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaminhoEntreCidades
{
    public class NoArvore<Dado> : IComparable<NoArvore<Dado>>
                                where Dado : IComparable<Dado>,
                                             IRegistro,
                                             new()
    {
        Dado info;
        public NoArvore<Dado> esq, dir;

        public NoArvore()
        {
            info = default(Dado);
            esq = dir = null;
        }

        public NoArvore(Dado informacao)
        {
            info = informacao;
            esq = dir = null;
        }

        public NoArvore(Dado informacao, NoArvore<Dado> e,
                                          NoArvore<Dado> d)
        {
            info = informacao;
            esq = e;
            dir = d;
        }
        public Dado Info
        { get => info; set => info = value; }
        public NoArvore<Dado> Esq
        { get => esq; set => esq = value; }
        public NoArvore<Dado> Dir
        { get => dir; set => dir = value; }

        public int CompareTo(NoArvore<Dado> outro)
        {
            if (outro != null)
                return this.info.CompareTo(outro.info);

            return -1;
        }

        public bool Equals(NoArvore<Dado> outro)
        {
            return this.info.Equals(outro.info);
        }

    }
}
