using System;

namespace Atividade1
{
    class Aplicacao
    {
        public const decimal Juros = 0.6M;
        static void Main(string[] args)
        {
            int sum = 1;
            int id_contaCorrente = 1;
            int id_contaPoupanca = 1;

            using (var dbcontext = new StoreContext())
            {

                dbcontext.Set<Agencia>().RemoveRange(dbcontext.Agencias);
                dbcontext.Set<Banco>().RemoveRange(dbcontext.Bancos);
                dbcontext.Set<Cliente>().RemoveRange(dbcontext.Clientes);
                dbcontext.Set<ContaCorrente>().RemoveRange(dbcontext.ContasCorrentes);
                dbcontext.Set<ContaPoupanca>().RemoveRange(dbcontext.ContasPoupanca);
                dbcontext.Set<Solicitacao>().RemoveRange(dbcontext.Solicitacoes);
                dbcontext.SaveChanges();




                Banco banco = new Banco();
                dbcontext.Bancos.Add(banco);
                dbcontext.SaveChanges();


                bool init = true;
                while (init)
                {
                    banco.listaIdAgencias();
                    MenuAgencia();
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Agencia agencia = new Agencia();
                            agencia.Id = sum;
                            banco.AdicionarAgencia(agencia);
                            sum++;

                            dbcontext.Agencias.Add(agencia);
                            dbcontext.SaveChanges();


                            break;
                        case 2:
                            Cliente cliente = new Cliente();
                            Console.WriteLine("Digite o nome do cliente: ");
                            string nome_cliente = Console.ReadLine();
                            cliente.Nome = nome_cliente;
                            dbcontext.Clientes.Add(cliente);
                            dbcontext.SaveChanges();

                            Console.WriteLine("Que tipo de conta deseja criar:\n");
                            Console.WriteLine("1 - Corrente / 2 - Poupança: ");
                            int tipo_conta = int.Parse(Console.ReadLine());
                            if (tipo_conta == 1)
                            {
                                ContaCorrente cc = new ContaCorrente(cliente.Nome);
                                Console.WriteLine("Digite o Id da agência: ");
                                int numAgencia = int.Parse(Console.ReadLine());

                                Agencia ag = banco.buscaAgencia(numAgencia);
                                if (ag != null)
                                {
                                    cc.Id = id_contaCorrente;
                                    ag.addContaCorrente(cc);
                                    id_contaCorrente++;
                                    dbcontext.ContasCorrentes.Add(cc);
                                    dbcontext.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine("Por favor tente novamente!");
                                }

                            }
                            else if (tipo_conta == 2)
                            {
                                ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);
                                Console.WriteLine("Digite o Id da agência: ");
                                int numAgencia = int.Parse(Console.ReadLine());

                                Agencia ag = banco.buscaAgencia(numAgencia);
                                if (ag != null)
                                {
                                    cp.Id = id_contaPoupanca;
                                    ag.addContaPoupanca(cp);
                                    id_contaPoupanca++;
                                    dbcontext.ContasPoupanca.Add(cp);
                                    dbcontext.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine("Por favor tente novamente!");
                                }

                            }


                            break;
                        case 3:
                            Solicitacao solicitacao = new Solicitacao();
                            solicitacao.realizarSolicitacao(banco);
                            dbcontext.Solicitacoes.Add(solicitacao);
                            dbcontext.SaveChanges();
                            break;
                        case 4:
                            banco.listaIdAgencias();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                        case 0:
                            init = false;
                            break;
                        default:
                            Console.WriteLine("Comando Inválido");
                            break;
                    }
                }
            }
        }
        public static void MenuAgencia()
        {
            Console.WriteLine("Banco TOGETHER");
            Console.WriteLine("1 - Cadastrar Agência  ");
            Console.WriteLine("2 - Criar Conta ");
            Console.WriteLine("3 - Abrir uma Sessão ");
            Console.WriteLine("4 - Listar agências ");
            Console.WriteLine("5 - Limpar tela");
            Console.WriteLine("0 - Sair");
        }
    }
}