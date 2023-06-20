using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using MedBooking.Models;

namespace MedBooking
{
    public partial class PacienteMenu : Form
    {
        private int _id_Paciente;
        public PacienteMenu(int id_paciente)
        {
            InitializeComponent();
            _id_Paciente = id_paciente;
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Lista de medicos | GET
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //Dar load com a lista mostrando todos os medicos
        private void PacienteMenu_Load(object sender, EventArgs e)
        {
            updateLista("", "");
            updateSlot();
            dateTimePicker1.MinDate = DateTime.Today;
        }

        private void updateLista(string nome, string especialidade)
        {
            var context = new MBcontext();

            //faz uma lista de contas chamada medico
            //onde o tipo de conta é 1 (medico)
            //filtra pelo nome e especialidade caso haja input do usuario
            var medico = context.Conta
                .Where(c => c.tipo_conta == 1 && c.nome.Contains(nome) && c.especialidade.Contains(especialidade))
                //.Select(c => new { c.nome, c.especialidade, c.telefone })
                //usando o Select eu crio uma lista de objetos anonimos e nao posso pegar esses dados depois na hora de criar a consulta
                .ToList();

            dataGridView1.DataSource = medico;

            dataGridView1.Columns["tipo_conta"].Visible = false;
            dataGridView1.Columns["id_conta"].Visible = false;
            dataGridView1.Columns["_id_user"].Visible = false;
        }

        //para nao usar botao, ver quando o texto muda em cada textbox e atualiza a lista
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateLista(textBox1.Text, textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            updateLista(textBox1.Text, textBox2.Text);
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        //quando selecionar uma data diferente mudar os slots 
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateSlot();
        }

        private void updateSlot()
        {
            var context = new MBcontext();
            
            //lista de slots de hora feita na utils.cs
            Dictionary<int, string> slots = Utils.getSlot();
            Dictionary<int, string> slotsDisponiveis = new Dictionary<int, string>();

            //selecionar slots ocupados
            DateTime dataOcupada = dateTimePicker1.Value.Date;

            var slotsOcupados = context.Slot
                .Where(s => s.Data_consulta == dataOcupada)
                .ToList();

            foreach(var slot in slots)
            {
                if(!slotsOcupados.Any(s => s.Hora_consulta == slot.Key.ToString()))
                {
                    slotsDisponiveis.Add(slot.Key, slot.Value);
                }
            }


            Horas.DataSource = slotsDisponiveis.ToList();
            Horas.DisplayMember = "Value";
            Horas.ValueMember = "Key";

        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Marcar consulta | CREATE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
       
        private void Reservar_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();

            int id_medico = 0;
            //validar se tem medico selecionado
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var objeto = dataGridView1.SelectedRows[0].DataBoundItem as Conta;

                id_medico = objeto.id_conta;
            }
            else
            {
                MessageBox.Show("Selecione um medico");
                return;
            }

            var newSlot = new Slot
            {
                Data_consulta = dateTimePicker1.Value.Date,
                Hora_consulta = Horas.SelectedValue.ToString()
            };

            context.Slot.Add(newSlot);
            context.SaveChanges();

            var newConsulta = new Consulta
            {
                _id_paciente = _id_Paciente,
                _id_medico = id_medico,
                status = "Marcada",
                id_slot = newSlot._id_slot
            };

            context.Consulta.Add(newConsulta);
            context.SaveChanges();

            MessageBox.Show("Consulta marcada com sucesso");

        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Historico de consultas | GET
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateListaConsulta(comboBox1.Text);
        }

        private void updateListaConsulta(string status)
        {
            var context = new MBcontext();

            var consulta = context.Consulta
                .Where(c => c._id_paciente == _id_Paciente && c.status == status)
                .ToList();

            dataGridView2.DataSource = consulta;

            dataGridView2.Columns["_id_consulta"].Visible = false;
            dataGridView2.Columns["_id_paciente"].Visible = false;
            dataGridView2.Columns["_id_medico"].Visible = false;
            dataGridView2.Columns["id_slot"].Visible = false;
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Desmarcar consulta | UPDATE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void Desmarcar(object sender, EventArgs e)
        {
            var context = new MBcontext();

            int id_consulta = 0;

            if(dataGridView2.SelectedRows.Count > 0)
            {
                var objeto = dataGridView2.SelectedRows[0].DataBoundItem as Consulta;
                id_consulta = objeto._id_consulta;
            }
            else
            {
                MessageBox.Show("Selecione uma consulta");
                return;
            }

            var consulta = context.Consulta
                .Where(c => c._id_consulta == id_consulta)
                .FirstOrDefault();

            if(consulta.status == "Cancelada")
            {
                MessageBox.Show("Consulta ja esta cancelada");
                return;
            }
            if(consulta.status == "Realizada")
            {
                MessageBox.Show("Consulta ja foi realizada");
                return;
            }

            consulta.status = "Cancelada";

            context.Update(consulta);
            context.SaveChanges();

            MessageBox.Show("Consulta desmarcada com sucesso");
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //Detalhes da consulta | GET
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void Detalhes_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();
            Utils utils = new Utils();

            if(dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma consulta");
                return;
            }

            var objeto = dataGridView2.SelectedRows[0].DataBoundItem as Consulta;

            var consultaMedico = context.Conta
                .Where(c => c.id_conta == objeto._id_medico)
                .Select(c => new { c.nome, c.especialidade, c.telefone })
                .ToList();

            var consultaSlot = context.Slot
                .Where(s => s._id_slot == objeto.id_slot)
                .Select(s => new { s.Data_consulta, s.Hora_consulta })
                .ToList();

            string nome = consultaMedico[0].nome;
            string especialidade = consultaMedico[0].especialidade;
            string telefone = consultaMedico[0].telefone;
            string data = consultaSlot[0].Data_consulta.ToString("dd/MM/yyyy");
            int key = int.Parse(consultaSlot[0].Hora_consulta);
            string hora = utils.horaSlot(key);

            string mensagem = $"Nome do Medico : {nome}\n" + 
                $"Especialidade : {especialidade}\n" + 
                $"Telefone para contato : {telefone}\n\n" + 
                $"Data : {data}\n" + 
                $"Hora : {hora}";

            MessageBox.Show(mensagem);
        }

        


    }
}
