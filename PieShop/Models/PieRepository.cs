using Microsoft.EntityFrameworkCore;
namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext _pieShopDbContext;

        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }


        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _pieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
