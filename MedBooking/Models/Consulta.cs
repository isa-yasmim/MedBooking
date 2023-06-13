using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedBooking.Models
{
    public partial class Consulta
    {
        [Key]
        public int id_consulta { get; set; }

        public int id_paciente { get; set; }

        public int id_medico { get; set; }

        public int id_slot { get; set; }

        public string notas { get; set; }
        public string status { get; set; }
    }
}
