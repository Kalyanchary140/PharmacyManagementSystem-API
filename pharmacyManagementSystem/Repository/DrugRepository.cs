using Microsoft.EntityFrameworkCore;
using pharmacyManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharmacyManagementSystem.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private readonly pharmacyManagamentContext _context;

        public DrugRepository(pharmacyManagamentContext context)
        {
            _context = context;
        }
        public DrugDetail Create(DrugDetail drugDetail)
        {
            _context.DrugDetails.Add(drugDetail);
            _context.SaveChanges();

            return drugDetail;
        }

        public void DeleteDrug(int id)
        {
            DrugDetail drug = GetDrug(id);
            _context.Remove(drug);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<DrugDetail>> GetAll()
        {
            return await _context.DrugDetails.ToListAsync();
        }
        public DrugDetail GetDrug(int id)
        {
            var drug = _context.DrugDetails.Where(u => u.DrugId == id).Include(c => c.OrderDetails).FirstOrDefault();
            return drug;
        }
        public DrugDetail GetDrugName(string drugName)
        {
            return _context.DrugDetails.FirstOrDefault(x => x.DrugName == drugName);
        }

        public void UpdateDrug(DrugDetail drugDetail)
        {
            _context.Entry(drugDetail).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
