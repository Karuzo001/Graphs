using System;
using System.Linq;
using Graphs;

namespace ConsoleGraphs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var key = true;
            while (key)
            {
                var graph = new Graph(10);

                Console.WriteLine("Введите ребра в формате: вершина1 вершина2 вес");
                Console.WriteLine("Каждое ребро на новой строке!!");
                Console.WriteLine("После окончания ввода всех ребер нажмите Enter");
                while (true)
                {
                    try
                    {
                        var tmp = Console.ReadLine();
                        if (tmp == "") break;
                        var qq = tmp.Split(' ');
                        graph.Add(new Edge(qq[0], qq[1], Convert.ToDouble(qq[2])));
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат ввода данных");
                    }
                }

                Console.WriteLine("\nРезультат");
                var result = SolutionMethods.KruskalAlgorithm(graph);
                result.Sort();
                Console.WriteLine($"\nВ минимальное свзывающее дерево будут входить следующие ребра:");
                for (var i = 0; i < result.Count(); i++)
                {
                    Console.Write($"({result.Edges[i].VertexA}, {result.Edges[i].VertexB}) ");
                }

                Console.WriteLine($"\nВес минимального связывающего дерева равен: {result.GetWeight()}");

                Console.WriteLine("Повторить? 1 - Да");
                if (Console.ReadLine() != "1") key = false;
            }
        }
    }
}