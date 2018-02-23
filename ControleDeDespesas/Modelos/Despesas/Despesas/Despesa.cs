using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Modelos
{
    public class Despesa : IDespesa
    {
        public IList<Despesas> Itens { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Despesa"/> class.
        /// </summary>
        /// <param name="i">The i.</param>
        public Despesa(IList<Despesas> i)
        {
            this.Itens = i;
        }


        /// <summary>
        /// Determines whether this instance has approved.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance has approved; otherwise, <c>false</c>.
        /// </returns>
        public bool HasApproved()
        {
            for (int i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].DataAprovacao != null )
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether [has not approved].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [has not approved]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasNotApproved()
        {
            for (int i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].DataReprovacao != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Despesa não sofreu nem aprovação e nem reprovação, está inalterada
        /// </summary>
        /// <returns></returns>
        public bool NoChange()
        {
            for(int i=0; i< Itens.Count; i++)
            {
                if(Itens[i].DataAprovacao!=null || Itens[i].DataReprovacao != null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// A Despesa foi aprovada ou reprovada
        /// </summary>
        /// <returns></returns>
        public bool ChangeAnyThing()
        {
            for (int i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].DataAprovacao != null || Itens[i].DataReprovacao != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hows the many itens.
        /// </summary>
        /// <returns></returns>
        public int HowManyItens()
        {
            return Itens.Count;
        }

        /// <summary>
        /// Soma o total dos itens
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public double Sum()
        {
            double soma=0;
            for(int i=0; i<Itens.Count; i++)
            {
                soma += Itens[i].Quantidade * Itens[i].Valor;
            }
            return soma;
        }
    }
}
