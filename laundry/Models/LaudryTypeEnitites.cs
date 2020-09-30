using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace laundry.Models
{
    [Table("LaundryType")]
    public class LaudryTypeEnitites
    {
        public int ID { get; set; }
        public string IdCode { get; set; }
        public string LaundryName { get; set; }
        public string Price { get; set; }
        public string Init { get; set;}
        public string Status { get; set; }
    }
}
