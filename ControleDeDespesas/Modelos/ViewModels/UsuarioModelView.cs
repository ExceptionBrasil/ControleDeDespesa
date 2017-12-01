using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class UsuarioModelView
    {
        public  int Id { get; set; }

        [Required]
        public  string Nome { get; set; }

        [Required]
        public  string Login { get; set; }

        [Required]
        public  string Senha { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public  string Email { get; set; }

        public  bool IsAdmin { get; set; }

        [Required]
        public  string Cpf { get; set; }

        [Required]
        public string CentroDeCusto { get; set; }

        [Required]
        public int Role { get; set; }
    }
}
