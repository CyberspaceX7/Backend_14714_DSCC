using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCC.CW1.Backend._14714.Model
{
    public class Member
    {
        [Key]  
        public int MemberId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [ForeignKey("Plan")]
        public int PlanId { get; set; }
        public MembershipPlan? Plan { get; set; }
    }
}
