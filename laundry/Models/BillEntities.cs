using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace laundry.Models
{
    [Table("Bills")]
    public class BillEntities
    {
       public int ID { get; set; }
       public string IdCode { get; set; }
       public string DateCreate { get; set; }
       public string TotalExpenses { get; set; }
       public string Status { get; set; }
    }
}
