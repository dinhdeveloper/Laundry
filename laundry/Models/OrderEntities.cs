using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace laundry.Models
{
    [Table("Orders")]
    public class OrderEntities
    {
        public int Id { get; set; }
        public string IdCode { get; set; }
        public int CustomerId { get; set; }
        public int LaundryTypeId { get; set; }
        public string AmountUnit { get; set; }
        public string OrderType { get; set; }
        public string Description { get; set; }
        public string TotalPayment { get; set; }
        public string Status { get; set; }
    }
}
