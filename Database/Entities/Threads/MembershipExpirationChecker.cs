using AutoMapper;
using Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.Threads
{
    public class MembershipExpirationChecker
    {
        public GymDbContext _context { get; }
        private readonly TimeSpan checkInterval = TimeSpan.FromMinutes(1); // Provera svakog dana

        public MembershipExpirationChecker(GymDbContext reactContext)
        {
            _context = reactContext;
        }

        public void Start()
        {
            TimerCallback callback = CheckMembershipExpiration;


            var timer = new Timer(callback, null, TimeSpan.Zero, checkInterval);
        }

        private void CheckMembershipExpiration(object state)
        {

            using (_context)
            {
                // Pronađite članstva koja ističu danas
                var membershipsToExpire = _context.Memberships
                .Where(m => m.ExpiryDate > DateTime.Now)
                .ToList();

                if (membershipsToExpire.Count > 0)
                {
                    foreach (var membership in membershipsToExpire)
                    {
                        membership.Client.Status = Enums.Status.Inactive;
                    }
                    _context.SaveChanges();
                }
            }
        }
    }
}
