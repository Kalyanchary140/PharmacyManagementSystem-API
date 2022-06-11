using Microsoft.EntityFrameworkCore;
using pharmacyManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace pharmacyManagementSystem.Repository
{
    public class SupplierRepository : ISuplierRepository
    {
        private readonly pharmacyManagamentContext _context;

        public SupplierRepository(pharmacyManagamentContext context)
        {
            _context = context;
        }
        public SupplierDetail Create(SupplierDetail supplierDetail)
        {
            _context.SupplierDetails.Add(supplierDetail);
            _context.SaveChanges();

            return supplierDetail;
        }
        public void DeleteSupplier(int id)
        {
            SupplierDetail supplier = GetSupplier(id);
            _context.Remove(supplier);
            _context.SaveChanges();
        }

        public IEnumerable<SupplierDetail> GetAll()
        {
            return _context.SupplierDetails.Include(drug => drug.DrugDetails).ToList();
        }
        public SupplierDetail GetSupplier(int id)
        {
            var supplier = _context.SupplierDetails.Where(u => u.SupplierId == id).Include(c => c.DrugDetails).FirstOrDefault();
            return supplier;
        }
        public void UpdateSupplier(SupplierDetail supplierDetail)
        {
            _context.Entry(supplierDetail).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
