using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; 
using MedBooking.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace MedBooking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validar se os campos foram preenchidos
            if (textBox1.Text  == "")
            {
                MessageBox.Show("Insira um nome de usuário");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Insira uma senha");
            }

            var context = new MBcontext();

            string username = textBox1.Text;
            string senha = textBox2.Text;

            var result = context.User.FirstOrDefault(u => u._username == username && u._senha == senha);

            //autenticar login
            if (result != null)
            {
                //admin e o unico nome de usuario disponivel para o admin
                //logo se a autenticacao da senha da certo iniciar o painel do admin ja direto
                if (textBox1.Text == "admin")
                {
                    MessageBox.Show("Bem vindo admin");
                    Hide();
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.ShowDialog();
                    Show();
                }

                //tipo da conta
                var conta_tipo = context.Conta
                    .Where(c => c._id_user == result._id_user)
                    .Select(c => c.tipo_conta)
                    .FirstOrDefault();
                //id conta
                var _id_conta = context.Conta
                    .Where(c => c._id_user == result._id_user)
                    .Select(c => c.id_conta)
                    .FirstOrDefault();

                if (conta_tipo == 1) // tipo_conta = 1 -> doctor
                {
                    // iniciar painel do medico
                    MessageBox.Show("Bem vindo medico");
                    Hide();
                    DoctorMenu doctorMenu = new DoctorMenu(_id_conta);
                    doctorMenu.ShowDialog();
                    Show();
                }
                else if (conta_tipo == 2) // tipo_conta = 2 -> paciente
                {
                    // iniciar painel do paciente
                    MessageBox.Show("Bem vindo paciente");
                    Hide();
                    PacienteMenu pacienteMenu = new PacienteMenu(_id_conta);
                    pacienteMenu.ShowDialog();
                    Show();
                }

            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
