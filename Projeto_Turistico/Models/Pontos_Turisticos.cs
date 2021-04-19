using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Turistico.Models
{
    [Table("Pontos_Turisticos")]
    public class Pontos_Turisticos
    {
        [Display(Name = "Id")]
        [Column("Id")]

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]

        public string Nome { get; set; }

        [Display(Name = "Descricao")]
        [Column("Descricao")]

        public string Descricao { get; set; }

        [Display(Name = "Referencia")]
        [Column("Referencia")]

        public string Referencia { get; set; }

        [Display(Name = "Cidade")]
        [Column("Cidade")]

        public string Cidade { get; set; }


    }
}
