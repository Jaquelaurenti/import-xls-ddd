using System;
using System.ComponentModel.DataAnnotations;

namespace ImportSpreadsheet.Domain.Entitys
{
    public class Import : Base
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        public string Directory { get; set; }
    }
}
