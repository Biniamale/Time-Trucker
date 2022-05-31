using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public DateTime EndingDate { get; set; }
        
        [Display(Name = "Project")]
        [Required]
        public virtual Project Project { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }

        [Display(Name = "Customer")]
        [Required]
        public virtual Customer Customer { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public string Description { get; set; }
    }
}
