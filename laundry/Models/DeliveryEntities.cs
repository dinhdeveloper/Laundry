using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace laundry.Models
{
    [Table("Delivery")]
    public class DeliveryEntities
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
