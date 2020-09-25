using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControle.Core.Models
{
    public class Marca
    {
        public string Marca_ID { get; set; }
        [StringLength(20)]
        [DisplayName("Nome Marca")]
        public string Marca_Titulo { get; set; }

        public Marca()
        {
            this.Marca_ID = Guid.NewGuid().ToString();
        }
    }
}
