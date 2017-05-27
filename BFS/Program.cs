using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    /// <summary>
    /// Represents Graph class
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// </summary>
        /// <value>
        /// The v.
        /// </value>
        private int V { get; set; }

        /// <summary>
        /// Gets or sets the adjacent vertices.
        /// </summary>
        /// <value>
        /// The adjacent vertices.
        /// </value>
        private LinkedList<int>[] AdjacentVertices { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        public Graph(int v)
        {
            this.V = v;
            this.AdjacentVertices = new LinkedList<int>[this.V];
            for(int i = 0; i < v; i++)
            {
                this.AdjacentVertices[i] = new LinkedList<int>();
            }
        }

        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <param name="w">The w.</param>
        public void AddEdge(int v, int w)
        {
            this.AdjacentVertices[v].AddLast(w);
        }

        /// <summary>
        /// </summary>
        /// <param name="startVertex">The start vertex.</param>
        public void BFS(int startVertex)
        {
            // This array is maintained to track the vertices that are visited
            bool []visited = new bool[this.V];

            LinkedList<int> queue = new LinkedList<int>();

            visited[startVertex] = true;

            queue.AddLast(startVertex);

            while(queue.Count != 0)
            {
                startVertex = queue.First.Value;
                Console.Write(startVertex + " ");
                queue.RemoveFirst();

                foreach(int vertex in this.AdjacentVertices[startVertex])
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        queue.AddLast(vertex);
                    }
                }
            }   
        }

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("List of visited nodes : ");

            g.BFS(1);
        }
    }
}
