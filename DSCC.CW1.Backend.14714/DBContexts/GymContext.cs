    using DSCC.CW1.Backend._14714.Model;
    using Microsoft.EntityFrameworkCore;


    namespace DSCC.CW1.Backend._14714.DBContexts
    {
        public class GymContext : DbContext
        {
            // Constructors DO NOT FORGET That Product Context class extends DB Context 
            public GymContext(DbContextOptions<GymContext> options) : base(options) { }

            public DbSet<Member> Members { get; set; }

            public DbSet<MembershipPlan> MembershipPlans { get; set; }
        }
    }
