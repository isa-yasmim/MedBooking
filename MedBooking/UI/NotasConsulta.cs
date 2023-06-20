using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedBooking.Models;

namespace MedBooking.UI
{
    public partial class NotasConsulta : Form
    {
        private int id_consulta;
        public NotasConsulta(int _id_consulta)
        {
            InitializeComponent();
            id_consulta= _id_consulta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();
            string notas = textNotas.Text;

            if(notas == "")
            {
                MessageBox.Show("Notas vazias");
                return;
            }
            else if(notas.Length > 255)
            {
                MessageBox.Show("Notas muito longas");
                return;
            }

            var consulta = context.Consulta
                .Where(c => c._id_consulta == id_consulta)
                .FirstOrDefault();

            consulta.notas = notas;

            context.Update(consulta);
            context.SaveChanges();

            MessageBox.Show("Notas atualizadas");
        }
    }
}
