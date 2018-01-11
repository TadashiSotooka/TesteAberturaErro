using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAberturaErro.Models
{
    public class Erros
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Severidade { get; set; }
        public string Descricao { get; set; }
        public string Produto { get; set; }
        public DateTime DataHora { get; set; }
        public string Email { get; set; }
    }
}
