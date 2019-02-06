using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class ContaPoupanca
    {
        private int id;
        private decimal taxaJuros;
        private DateTime dataAniversario;
        private string titular = string.Empty;

        public ContaPoupanca()
        {

        }

        public ContaPoupanca(decimal j, DateTime d, string t)
        {
            this.titular = t;
            taxaJuros = j;
            dataAniversario = d;
        }

        public decimal Juros { get; set; }
        public DateTime DataAniversario { get; set; }

        public void AdicionarRendimento()
        {
            if (DateTime.Now.Equals(dataAniversario))
            {
                decimal rendimento;
                rendimento = Saldo * taxaJuros;
                Depositar(rendimento);
            }
        }
        [Key]
        public int Id { get; set; }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
        }

        public decimal Saldo { get; set; }

        public string Titular { get; set; }
    }
}