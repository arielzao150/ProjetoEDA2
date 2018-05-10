using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEDA2
{
    public class Node
    {
        #region Atributos
        private string nome;
        private List<Edge> vizinhos;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }
        public List<Edge> Vizinhos
        {
            get
            {
                return vizinhos;
            }
        }
        #endregion

        #region Construtor
        public Node(string nome)
        {
            this.nome = nome;
            vizinhos = new List<Edge>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica se uma cidade vizinha já está na lista de vizinhos
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool JaEVizinho(Node B)
        {
            foreach(Edge aresta in vizinhos)
            {
                if (aresta.B == B)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Adiciona uma cidade como vizinha de outra
        /// </summary>
        /// <param name="vizinho"></param>
        public void AddVizinho(Node vizinho)
        {
            if (vizinho == this)
            {
                Console.WriteLine("Você não pode inserir a própria cidade como vizinho!");
                return;
            }

            if (vizinho == null)
            {
                Console.WriteLine("Cidade não encontrada!");
                return;
            }

            if (!JaEVizinho(vizinho))
            {
                vizinhos.Add(new Edge(this, vizinho));
                vizinho.AddVizinho(this);
            }
        }

        public override string ToString()
        {
            return nome;
        }
        #endregion
    }
}
