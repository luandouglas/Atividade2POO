using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Banco
    {
        private int id;

        List<Agencia> agencias = new List<Agencia>();

        public void AdicionarAgencia(Agencia agencia)
        {

            agencias.Add(agencia);
            WriteLine("Agência " + agencia.Id + " criada com sucesso!");
            WriteLine("Numero de agencias: " + (agencias.Count) + "\n");
        }


        public Agencia buscaAgencia(int num)
        {
            Agencia ag = null;
            foreach (var agencia in agencias)
            {
                if (agencia.Id == num)
                {
                    ag = agencia;
                    return ag;
                }
            }
            WriteLine("Dados errados ou Agencia existe, tente novamente.\n");
            return null;


        }

        public bool listaIdAgencias()
        {
            if (agencias.Count == 0)
            {
                WriteLine("Nenhuma agência cadastrada");
                return false;
            }
            else
            {
                WriteLine("Agências");
                foreach (var agencia in agencias)
                {
                    WriteLine("Ag: " + agencia.Id);
                }
                return true;
            }
        }
        [Key]
        public int Id { get; set; }

        public List<Agencia> Agencias { get; }

    }
}
