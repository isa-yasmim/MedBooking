using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedBooking.Models
{
    public partial class Conta
    {

        [Key]
        public int id_conta { get; set; }

        public int id_user { get; set; }

        public int tipo_conta { get; set; }

        public string nome { get; set; }

        public string telefone { get; set; }

        //nulo para conta de paciente e admin
        public string especialidade { get; set; }
    }
}
