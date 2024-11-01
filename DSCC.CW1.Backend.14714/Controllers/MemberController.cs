using DSCC.CW1.Backend._14714.Model;
using DSCC.CW1.Backend._14714.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC.CW1.Backend._14714.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IMemberRepository _memberRepository;
        public MemberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // GET: api/<MemberController>
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetMembers()
        {
            var members = _memberRepository.GetMembers();
            return Ok(members);
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<Member> GetMemberById(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Member not found.");
            }
            return Ok(member);
        }

        // POST api/<MemberController>
        [HttpPost]
        public ActionResult CreateMember([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest("Member is null.");
            }
            _memberRepository.InsertMember(member);
            return CreatedAtRoute("GetMemberById", new { id = member.MemberId }, member);
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, [FromBody] Member member)
        {
            if (member == null || member.MemberId != id)
            {
                return BadRequest("Member Id does not match.");
            }

            var existingMember = _memberRepository.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound("Member not found.");
            }

            _memberRepository.UpdateMember(member);
            return NoContent();
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound("Member not found.");
            }

            _memberRepository.DeleteMember(id);
            return NoContent();
        }
    }
}
