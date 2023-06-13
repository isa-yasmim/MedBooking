using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedBooking.Models
{
    internal class Slot
    {
        [Key]
        public int id_slot { get; set; }

        public DateTime data_hora_consulta { get; set; }
    }
}
