using Microsoft.EntityFrameworkCore;
using GoiabinhaRoom.Models;

namespace GoiabinhaRoom.Data
{
    public class GoiabinhaRoomContext : DbContext
    {
        public GoiabinhaRoomContext(DbContextOptions<GoiabinhaRoomContext> options)
            : base(options)
        {
        }

        public DbSet<Goiabinha> Goiabinha { get; set; }
    }
}