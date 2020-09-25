using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControle.Core.Models
{
   public class Viatura
    {
        public string Viatura_ID { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public string Cor { get; set; }
        public string Cilindrada { get; set; }
        public string Portas { get; set; }
        public string Lugares { get; set; }
        [Range(0,1000)]
        public decimal Valores_Aquisicao { get; set; }
        public DateTime Data_aquisicao { get; set; }
        public string Estado { get; set; }
        public DateTime Data_Registo { get; set; }
        public decimal Peso_Bruto { get; set; }
        public decimal Peso_Liquido { get; set; }
        public string Imagem { get; set; }

        public Viatura()
        {
            this.Viatura_ID = Guid.NewGuid().ToString();
        }
    }
}
