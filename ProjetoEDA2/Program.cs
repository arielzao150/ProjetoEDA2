using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEDA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph estado = new Graph();
            Console.WriteLine("Insira o numero de cidades: ");
            int qnt = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < qnt; i++)
            {
                Console.WriteLine("Insira o nome da cidade {0}: ", i+1);
                string nome = Console.ReadLine();
                if (estado.ProcuraCidade(nome) == null)
                    estado.AddCidade(nome);
                else
                {
                    Console.WriteLine("Cidade já adicionada!");
                    i--;
                }
            }

            Console.WriteLine("");
            Console.WriteLine("As cidades são:");
            estado.MostraCidades();
            Console.WriteLine("");

            foreach (Node no in estado.Cidades)
            {
                while(true)
                {
                    Console.WriteLine("Insira os vizinhos de {0} (em branco para ir para próxima cidade):", no.Nome);
                    string nome = Console.ReadLine();
                    if (string.IsNullOrEmpty(nome))
                        break;
                    else
                        estado.AddVizinho(no, nome);
                }
            }

            Console.WriteLine("");
            estado.MostraVizinhos();
            Console.WriteLine("");
            
            //estado.EmissoraDeTelevisao();            
            Console.WriteLine("O número minimo de emissoras é: {0}", estado.MetodoDouglas().ToString());
            estado.MostraEmissoras();
            

            Console.ReadKey();
        }
    }
}
