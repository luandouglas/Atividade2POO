using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class ContaCorrente
    {
        public const decimal Taxa = 0.10M;
        private int id;
        private string titular = string.Empty;
        private decimal saldo;

        public ContaCorrente(string t)
        {
            Titular = t;
        }
        public ContaCorrente()
        {

        }


        public void Depositar(decimal valor)
        {
            decimal desconto = valor * Taxa;
            Saldo += valor;
        }
        public void Sacar(decimal valor)
        {
            decimal desconto = valor * Taxa;

            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
        }
        public string Titular { get; set; }
        public int Id { get; set; }
        public decimal Saldo { get; set; }
    }
}
