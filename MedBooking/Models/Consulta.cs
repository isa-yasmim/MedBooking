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
        private int id_consulta { get; set; }

        private int id_paciente { get; set; }

        private int id_medico { get; set; }

        public int id_slot { get; set; }

        public string notas { get; set; }
        public string status { get; set; }

        public int _id_consulta
        {
            get { return id_consulta; }
            set { id_consulta = value; }
        }

        public int _id_paciente
        {
            get { return id_paciente; }
            set { id_paciente = value; }
        }

        public int _id_medico
        {
            get { return id_medico; }
            set { id_medico = value; }
        }
    }
}
