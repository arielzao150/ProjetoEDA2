using System;
using System.Collections.Generic;

namespace ProjetoEDA2
{
    public class Graph
    {
        #region Atributos
        private List<Node> cidades;
        public List<Node> Cidades
        {
            get
            {
                return cidades;
            }
        }
        #endregion

        #region Construtor
        public Graph()
        {
            cidades = new List<Node>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Adiciona uma cidade à lista de cidades
        /// </summary>
        /// <param name="nome"></param>
        public void AddCidade(string nome)
        {
            cidades.Add(new Node(nome));
        }

        /// <summary>
        /// Procura uma cidade na lista de cidades
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Node ProcuraCidade(string nome)
        {
            foreach(Node no in cidades)
            {
                if (string.Compare(no.Nome, nome) == 0)
                    return no;
            }
            return null;
        }

        public void AddVizinho(Node A, string B)
        {
            A.AddVizinho(ProcuraCidade(B));
        }

        public void MostraCidades()
        {
            foreach(Node no in cidades)
            {
                Console.WriteLine(no.Nome);
            }
        }

        public void MostraVizinhos()
        {
            foreach(Node no in cidades)
            {
                Console.WriteLine("Vizinhos de {0}:", no.Nome);
                foreach (Edge aresta in no.Vizinhos)
                    Console.WriteLine(aresta.B);
            }
        }

        public void CleanNodes()
        {
            foreach(Node clean in cidades)
                clean.Visited = false;
        }

        /// <summary>
        /// Resolve o problema.
        /// </summary>
        public void EmissoraDeTelevisao()
        {
            // Deixa todas as cidades como não visitadas
            CleanNodes();

            List<int> emissorasImpossiveis = new List<int>();

            foreach (Node cidade in cidades)
            {
                if (!cidade.Visited)
                    foreach (Edge vizinho in cidade.Vizinhos)
                        if (vizinho.B.emissora != 0)
                            emissorasImpossiveis.Add(vizinho.B.emissora);
            }
            throw new NotImplementedException();
        }
        #endregion
    }
}