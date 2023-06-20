using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;

namespace MedBooking.Models
{
    public partial class Slot
    {
        [Key]
        private int id_slot { get; set; }

        private DateTime data_consulta { get; set; }

        private string hora_consulta { get; set; }

        public int _id_slot
        {
            get { return id_slot; }
            set { id_slot = value; }
        }   

        public DateTime Data_consulta
        {
            get { return data_consulta; }
            set 
            { 
                if(value.Date < DateTime.Today)
                {
                    MessageBox.Show("Selecione outro dia");
                    return;
                }
                else if(value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Selecione outro dia");
                    return;
                }
                else
                {
                    data_consulta = value;  
                }
            }
        }

        public string Hora_consulta
        {
            get { return hora_consulta; }
            set { hora_consulta = value; }
        }   

    }
}
