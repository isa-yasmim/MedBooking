using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Selectors;
using System.Windows.Forms;

namespace MedBooking.Models
{
    public partial class User
    {
        [Key]
        private int id_user { get; set; }

        private string username { get; set; }

        private string senha { get; set; }

        public string _username
        {
            get { return username; }
            set { 
                if (value == "")
                {
                    MessageBox.Show("Valor de username vazio");
                    return;
                }
                else
                {
                    username = value;
                }
            }
        }

        public string _senha
        {
            get { return senha; }
            set { 
                if (value == "")
                {
                    MessageBox.Show("Valor de senha vazio");
                    return;
                }
                else
                {
                    senha = value;
                }
            }
        }

        public int _id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

    }
}
