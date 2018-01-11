using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.ViewModels
{
    public class CentroDeCustoModelView
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Tamanho máximo permitido 20 caracteres")]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        
        public int Aprovador { get; set; }
    }
}
