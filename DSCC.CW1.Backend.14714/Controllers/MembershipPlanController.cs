using DSCC.CW1.Backend._14714.Model;
using DSCC.CW1.Backend._14714.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC.CW1.Backend._14714.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlanController : ControllerBase
    {

        private readonly IMembershipRepository _membershipRepository;

        public MembershipPlanController(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }




        // GET: api/<MembershipPlanController>
        [HttpGet]
        public ActionResult<IEnumerable<MembershipPlan>> GetMembershipPlans()
        {
            var plans = _membershipRepository.GetMembershipPlans();
            return Ok(plans);
        }

        // GET api/<MembershipPlanController>/5
        [HttpGet("{id}", Name = "GetMembershipPlanById")]
        public ActionResult<MembershipPlan> GetMembershipPlanById(int id)
        {
            var plan = _membershipRepository.GetMembershipPlanId(id);
            if (plan == null)
            {
                return NotFound("Membership plan not found.");
            }
            return Ok(plan);
        }

        // POST api/<MembershipPlanController>
        [HttpPost]
        public ActionResult CreateMembershipPlan([FromBody] MembershipPlan membershipPlan)
        {
            if (membershipPlan == null)
            {
                return BadRequest("Membership plan is null.");
            }

            _membershipRepository.InsertMembershipPlan(membershipPlan);
            return CreatedAtRoute("GetMembershipPlanById", new { id = membershipPlan.PlanId }, membershipPlan);
        }

        // PUT api/<MembershipPlanController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMembershipPlan(int id, [FromBody] MembershipPlan membershipPlan)
        {
            if (membershipPlan == null || membershipPlan.PlanId != id)
            {
                return BadRequest("Membership plan Id does not match.");
            }

            var existingPlan = _membershipRepository.GetMembershipPlanId(id);
            if (existingPlan == null)
            {
                return NotFound("Membership plan not found.");
            }

            _membershipRepository.UpdateMembershipPlan(membershipPlan);
            return NoContent();
        }



        // DELETE api/<MembershipPlanController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMembershipPlan(int id)
        {
            var plan = _membershipRepository.GetMembershipPlanId(id);
            if (plan == null)
            {
                return NotFound("Membership plan not found.");
            }

            _membershipRepository.DeleteMembershipPlan(id);
            return NoContent();
        }
    }
}
