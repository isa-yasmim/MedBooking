using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedBooking.Models
{
    public partial class User
    {
        [Key]
        public int id_user { get; set; }

        public string username { get; set; }

        public string senha { get; set; }
    }
}
