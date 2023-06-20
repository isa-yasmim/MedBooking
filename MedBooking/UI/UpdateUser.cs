using MedBooking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedBooking.UI
{
    public partial class UpdateUser : Form
    {
        private Conta _conta;
        public UpdateUser(Conta conta)
        {
            InitializeComponent();
            _conta = conta;
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            //mostra a conta que está sendo atualizada, recebe esse valor do form AdminMenu
            label2.Text = "Nome: " + _conta.nome + "\nTipo_conta:" + _conta.tipo_conta + "\nTelefone:" + _conta.telefone + "\nEspecialidade:" +
                _conta.especialidade;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();

            //pode atualizar nome e telefone somente
            //ambos podem ser atualizados ou somente um deles
            if (nomeU.Text == "")
            {
                if (TelefoneU.Text == "")
                {
                    //se nenhum campo for preenchido nao atualiza
                    MessageBox.Show("Preencha um dos campos");
                    return;
                }
            }
            if(nomeU.Text != "")
            {
                _conta.nome = nomeU.Text;
            }
            if(TelefoneU.Text != "")
            {
                _conta.telefone = TelefoneU.Text;
            }
            context.Update(_conta);
            context.SaveChanges();
            MessageBox.Show("Cadastro atualizado");
        }
    }
}
