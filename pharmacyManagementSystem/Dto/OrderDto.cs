using System;

namespace pharmacyManagementSystem.Dto
{
    public class OrderDto
    {
        public int? DrugId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime OrderPickedUp { get; set; } = DateTime.Now;
        public decimal? OrderPrice { get; set; }
    }
}
