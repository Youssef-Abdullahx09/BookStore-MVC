using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cover Type")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
