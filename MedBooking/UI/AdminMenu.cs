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
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace MedBooking
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //buscar conta function | GET
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void updateLista(string nome)
        {
            var context = new MBcontext();

            var conta = context.Conta
                .Where(c => c.nome.Contains(nome))
                .Select(c => new
                {
                    c.id_conta,
                    c.nome,
                    c.telefone,
                    c.tipo_conta,
                    c.especialidade
                })
                .ToList();
            //faz uma lista dos atributos do usuario

            Lista.Items.Clear();

            if (conta.Count > 0)
            {
                foreach (var item in conta)
                {
                    //lista os atributos do usuario cujo nome foi pesquisado
                    Lista.Items.Add($"Account ID: {item.id_conta}");
                    Lista.Items.Add($"Nome: {item.nome}");
                    Lista.Items.Add($"Telefone: {item.telefone}");
                    Lista.Items.Add($"Tipo de conta: {item.tipo_conta}");
                    Lista.Items.Add($"Especialidade: {item.especialidade}");
                    Lista.Items.Add(""); 
                }
            }
            else
            {
                Lista.Items.Add("Nenhuma conta correspondente");
            }
        }
        private void AdminMenu_Load(object sender, EventArgs e)
        {
            updateLista("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateLista(textBox1.Text);
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        //criar conta admin function  | CREATE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void button1_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();

            //user
            string username = usernameF.Text;
            string senha = senhaF.Text;
            //conta
            string nome = nomeF.Text;
            string telefone = telefoneF.Text;
            string tipo= tipoF.Text;
            int tipo_conta = 0;
            string especialidade = especialidadeF.Text;

            //so cria conta caso o usuario seja criado
            bool userCriado = false;

            //- - - - - - - - - - - - - - 
            //validar campos de user
            //- - - - - - - - - - - - - -
            if (username == "")
            {
                MessageBox.Show("Insira um nome de usuário");
            }
            else if (senha == "")
            {
                MessageBox.Show("Insira uma senha");
            }
            else if (context.User.Any(u => u.username == username))//validar se ja tem um usuario com o mesmo username, para evitar conflitos no banco
            {
                MessageBox.Show("Nome de usuário já existe");
                userCriado = false;
            }
            else
            {

                var newUser = new User
                {
                    username = username,
                    senha = senha
                };

                context.User.Add(newUser);
                context.SaveChanges();

                userCriado = true;
            }
            //- - - - - - - - - - - - - - 
            //criar conta
            //- - - - - - - - - - - - - - 

            //precisa do id_user para criar a conta
            var id_user = context.User
                .Where(u => u.username == username && u.senha == senha)
                .Select(u => u.id_user)
                .FirstOrDefault();

            if (userCriado == true)
            {
                //validar campos
                if (nome == "")
                {
                    MessageBox.Show("Insira um nome");
                }
                else if (telefone == "")
                {
                    MessageBox.Show("Insira um telefone");
                }
                if (tipo == "medico")
                {
                    tipo_conta = 1;
                }
                else if (tipo == "paciente")
                {
                    tipo_conta = 2;
                }
                if (tipo_conta == 0)
                {
                    MessageBox.Show("Insira um tipo de conta");
                }
                //especialidade e null, somente preencher para medicos
                else
                {
                    var newConta = new Conta
                    {
                        nome = nome,

                        telefone = telefone,
                        id_user = id_user,
                        tipo_conta = tipo_conta,
                        especialidade = especialidade
                    };

                    context.Conta.Add(newConta);

                    //catch possivel erro com o bd
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Registro feito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados: " + ex.Message);
                    }

                }
            }
          
        }

        private void AdminMenu_Load_1(object sender, EventArgs e)
        {

        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // deletar conta function  | DELETE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        
        private void delete_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();
            //validando a variavel
            int id_conta = 0;

            //verificar se o campo foi preenchido
            //precisa fazer isso antes de ler o valor do campo, senao da erro pq ele nao consegue converter "" para int
            if (DeleteId.Text == "")
            {
                MessageBox.Show("Insira um ID");
                return;
            }
            else
            {
                try
                {
                    id_conta = int.Parse(DeleteId.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (context.Conta.Any(c => c.id_conta == id_conta))
            {
                var conta = context.Conta
                    .Where(c => c.id_conta == id_conta)
                    .FirstOrDefault();

                string mensagem = $"Deseja confirmar a exclusão da conta?\n\nID da Conta: {conta.id_conta}\nNome: {conta.nome}\nTelefone: {conta.telefone}\nTipo de conta: {conta.tipo_conta}\nEspecialidade: {conta.especialidade}";

                DialogResult result = MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //achar o id do user
                    var user = context.User
                        .Where(u => u.id_user == conta.id_user)
                        .FirstOrDefault();

                    //remover
                    context.Conta.Remove(conta);
                    context.User.Remove(user);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Conta deletada");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar os dados: " + ex.Message);
                    }
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("ID não encontrado");
            }
        }

        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        // atualizar conta function  | UPDATE
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        private void button2_Click(object sender, EventArgs e)
        {
            var context = new MBcontext();

            //validando a variavel
            int id_conta = 0;
        }
    }
}
