using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace laundry.Models
{
    [Table("Customer")]
    public class CustomerEntities
    {
       
        public virtual int Id { get; set; }
        public virtual string IdCode { get; set; }
        public virtual string FullName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Status { get; set; }
    
    }
}
