
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ImportSpreadsheet.Application.Dtos
{
    [Table("Import")]
    public class ImportDTO
    {
        [Column("ID")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("Directory")]
        [StringLength(50)]
        [Required]
        public string Directory { get; set; }

    }
}
