using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CoverType
    {
        public CoverType()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
