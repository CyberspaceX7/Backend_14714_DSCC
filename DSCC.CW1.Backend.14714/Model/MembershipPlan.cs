using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DSCC.CW1.Backend._14714.Model
{
    public class MembershipPlan
    {
        [Key]  
        public int PlanId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PlanName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
    }
}
