using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Solicitacao
    {
        private int id;
        public void realizarSolicitacao(Banco banco)
        {
            Console.WriteLine("Núemro da agência: ");
            int numAgencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Tipo da conta: 1 - Corrente/ 2 - Poupança");
            int tipo_conta = int.Parse(Console.ReadLine());

            if (tipo_conta == 1)
            {

                Agencia agencia = banco.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }

                Console.WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(Console.ReadLine());

                ContaCorrente cc = agencia.getCCorrente(num_conta);
                if (cc == null)
                {
                    return;
                }

                Console.WriteLine("1 - Consultar Saldo \n2 - Sacar \n3 -  Depositar\n");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    Console.WriteLine("Situação");
                    Console.WriteLine("Conta: " + cc.Id);
                    Console.WriteLine("Titular: " + cc.Titular);
                    Console.WriteLine("Seu saldo é R$ " + cc.Saldo);
                }
                else if (operacao == 2)
                {
                    Console.WriteLine("Valor: ");
                    cc.Sacar(decimal.Parse(Console.ReadLine()));

                }
                else if (operacao == 3)
                {
                    Console.WriteLine("Valor: ");
                    cc.Depositar(decimal.Parse(Console.ReadLine()));
                }
            }
            else if (tipo_conta == 2)
            {
                Console.WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(Console.ReadLine());
                Agencia agencia = banco.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }
                ContaPoupanca cp = agencia.getCPoupanca(num_conta);
                if (cp == null)
                {
                    return;
                }

                Console.WriteLine("1 - Consultar Saldo / 2 - Sacar / 3 -  Depositar");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    Console.WriteLine("Conta: " + cp.Id);
                    Console.WriteLine("Titular: " + cp.Titular);
                    Console.WriteLine("Seu saldo é R$ " + cp.Saldo);
                }
                else if (operacao == 2)
                {
                    Console.WriteLine("Valor: ");
                    cp.Sacar(decimal.Parse(Console.ReadLine()));
                }
                else if (operacao == 3)
                {
                    Console.WriteLine("Valor: ");
                    cp.Depositar(decimal.Parse(Console.ReadLine()));
                }
            }
        }

        [Key]
        public int Id { get; set; }

    }
}
