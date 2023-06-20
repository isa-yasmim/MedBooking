using MedBooking.Models;
using MedBooking.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedBooking
{
    public partial class DoctorMenu : Form
    {
        private int id_medico;
        public DoctorMenu(int _id_conta)
        {
            InitializeComponent();
            id_medico = _id_conta;
            updateLista("", "");
        }

        private void DoctorMenu_Load(object sender, EventArgs e)
        {

        }

        private void updateLista(string paciente, string status)
        {
            var context = new MBcontext();

            var Paciente = context.Conta
                .Where(c => c.tipo_conta == 2 && c.nome.Contains(paciente))
                .FirstOrDefault();

            if (Paciente != null)
            {
                int id_paciente = Paciente.id_conta;

                var consulta = context.Consulta
                    .Where(c => c._id_medico == id_medico && c.status == status && c._id_paciente == id_paciente)
                    .ToList();

                if (textPaciente.Text == null)
                {
                    consulta = context.Consulta
                        .Where(c => c._id_medico == id_medico && c.status == status)
                        .ToList();
                }

                dataGridView1.DataSource = consulta;

                dataGridView1.Refresh();
                dataGridView1.Columns["_id_consulta"].Visible = false;
                dataGridView1.Columns["_id_medico"].Visible = false;
            }
        }

        private void textPaciente_TextChanged(object sender, EventArgs e)
        {
            updateLista(textPaciente.Text, comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateLista(textPaciente.Text, comboBox1.Text);
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Adicionar notas e marcar como realizada | UPDATE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void Realizar_Click(object sender, EventArgs e)
        {

            var context = new MBcontext();

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma consulta");
                return;
            }

            var consulta = dataGridView1.SelectedRows[0].DataBoundItem as Consulta;
            int id_consulta = consulta._id_consulta;

            if (consulta.status == "Realizada")
            {
                MessageBox.Show("Consulta já realizada");
                return;
            }

            var newConsulta = context.Consulta
                .Where(c => c._id_consulta == id_consulta)
                .FirstOrDefault();

            NotasConsulta notasConsulta = new NotasConsulta(id_consulta);
            notasConsulta.ShowDialog();

            newConsulta.status = "Realizada";

            context.Update(newConsulta);
            context.SaveChanges();

        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Deatlhes da consulta | GET
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void Detalhes_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();
            Utils utils = new Utils();

            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma consulta");
                return;
            }

            var objeto = dataGridView1.SelectedRows[0].DataBoundItem as Consulta;

            var Paciente = context.Conta
                .Where(c => c.id_conta == objeto._id_paciente)
                .FirstOrDefault();

            var Slot = context.Slot
                .Where(s => s._id_slot == objeto.id_slot)
                .FirstOrDefault();

            string nome = Paciente.nome;
            string telefone = Paciente.telefone;
            string data = Slot.Data_consulta.ToString("dd/MM/yyyy");
            int key = int.Parse(Slot.Hora_consulta);
            string hora = utils.horaSlot(key);

            string mensagem = $"Paciente : {nome}\n" +
                $"Telefone : {telefone}\n\n" +
                $"Data : {data}\n" +
                $"Hora : {hora}";

            MessageBox.Show(mensagem);

        }
    }
}
