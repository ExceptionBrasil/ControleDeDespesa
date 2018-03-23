using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    /// <summary>
    /// Classe ModelView para recuperação de senha 
    /// </summary>
    public class RecoverPasswordModelView
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(AllowEmptyStrings =false,ErrorMessage ="Esse campo é obrigatório!")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set; }
    }
}
