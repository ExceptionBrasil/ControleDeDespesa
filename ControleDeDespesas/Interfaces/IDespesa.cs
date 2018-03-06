using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
   public  interface IDespesa
    {
       

        /// <summary>
        /// Determines whether this instance has approved.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has approved; otherwise, <c>false</c>.
        /// </returns>
        bool HasApproved();

        

        /// <summary>
        /// Determines whether [has not approved].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has not approved]; otherwise, <c>false</c>.
        /// </returns>
        bool HasNotApproved();
        /// <summary>
        /// Hows the many itens.
        /// </summary>
        /// <returns></returns>
        int HowManyItens();

        /// <summary>
        /// Despesa não sofreu nem aprovação e nem reprovação, está inalterada
        /// </summary>
        /// <returns></returns>
        bool NoChange();

        /// <summary>
        /// A Despesa foi aprovada ou reprovada 
        /// </summary>
        /// <returns></returns>
        bool ChangeAnyThing();

        /// <summary>
        /// Soma o total dos itens
        /// </summary>
        /// <returns></returns>
        double Sum();

        


    }
}
