using System;
using System.Collections.Generic;

namespace ProjetoEDA2
{
    public class Graph
    {
        #region Atributos
        private List<int> emissorasFinal;
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

        public void MostraEmissoras()
        {
            foreach(Node no in cidades)
            {
                Console.WriteLine("emissora de {0} é:", no.Nome);
                Console.WriteLine(no.emissora.ToString());
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



        public int MetodoDouglas()
        {
            List<int> emissoras = new List<int>();
            int emissoraNova = 0;

            // Deixa todas as cidades como não visitadas
            CleanNodes();

            Queue<Node> Q = new Queue<Node>();

            Random rnd = new Random();
            int r = rnd.Next(cidades.Count);
            Node primeiro = cidades[r];

            primeiro.Visited = true;   
            emissoraNova++;
            emissoras.Add(emissoraNova);
            primeiro.emissora = emissoraNova;

            Q.Enqueue(primeiro);

            while (Q.Count != 0)
            {
                Node N = Q.Dequeue();
                foreach (Edge aresta in N.Vizinhos)
                {
                    if (!aresta.B.Visited)
                    {
                        //Pegando todas as emissoras das cidades vizinhas
                        List<int> emissorasVizinhos = new List<int>();
                        foreach (Edge caminhoVizinho in aresta.B.Vizinhos)
                        {
                            emissorasVizinhos.Add(caminhoVizinho.B.emissora);
                        }

                        //Verifica se alguma das emissora existentes não está entre
                        //as emissoras das cidades vizinhas. Se tiver, eu adiciono essa emissora para
                        //a cidade atual
                        foreach (int emissoraExistente in emissoras)
                        {                                                 
                            if(!emissorasVizinhos.Contains(emissoraExistente) && aresta.B.emissora == -1) 
                            {
                                aresta.B.emissora = emissoraExistente;
                            }                                    
                        }
                        //Caso todas emissoras existentes ja estejam entre os vizinhos
                        //Criamos uma nova
                        if(aresta.B.emissora == -1)
                        {
                            emissoraNova++;
                            emissoras.Add(emissoraNova);
                            aresta.B.emissora = emissoraNova;
                        }                        

                        Q.Enqueue(aresta.B);
                        aresta.B.Visited = true;
                    }
                }
            }
            emissorasFinal = emissoras;
            return emissoras.Count;
        }
        #endregion
    }
}