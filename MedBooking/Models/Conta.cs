﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace MedBooking.Models
{
    public partial class Conta
    {

        [Key]
        public int id_conta { get; set; }

        private int id_user { get; set; }

        public int tipo_conta { get; set; }

        public string nome { get; set; }

        public string telefone { get; set; }

        //nulo para conta de paciente e admin
        public string especialidade { get; set; }

        public Conta()
        {

        }

        public Conta(int id_conta, int id_user, int tipo_conta, string nome, string telefone, string especialidade)
        {
            this.id_conta = id_conta;
            this.id_user = id_user;
            this.tipo_conta = tipo_conta;
            this.nome = nome;
            this.telefone = telefone;
            this.especialidade = especialidade;
        }

        public int _id_user
        {
            get { return id_user; }
            set { 
                var context = new MBcontext();
                if (context.User.Find(value) == null)
                {
                    //throw new exception tambem funciona
                    MessageBox.Show("Valor de id_user não existe");
                    return;
                }
                else
                {
                    id_user = value;
                }   
            }
        }
    }
}
