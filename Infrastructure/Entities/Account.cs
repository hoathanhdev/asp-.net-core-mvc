using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    [Table("wsAccount")]
    public class Account
    {
        [Key]
        public int aID { get; set; }
        public string aUsername { get; set; }
        public string aPassword { get; set; }
        public bool aIsAdmin { get; set; }
        public string aInformation { get; set; }
        public string aEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActived { get; set; }

    }
}
