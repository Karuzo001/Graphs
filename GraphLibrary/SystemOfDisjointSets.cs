using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs;

public class SystemOfDisjointSets
{
    public List<Set> Sets ;

    public SystemOfDisjointSets()
    {
        Sets = [];
    }

    public SystemOfDisjointSets(Edge edge)
    {
        Sets = [new Set(edge)];
    }

    public void AddEdgeInSet(Edge edge)
    {
        var setA = Find(edge.VertexA);
        var setB = Find(edge.VertexB);

        if (setA != null && setB == null)
        {
            setA.AddEdge(edge);
        }
        else if (setA == null && setB != null)
        {
            setB.AddEdge(edge);
        }
        else if (setA == null && setB == null)
        {
            Sets.Add(new Set(edge));
        }
        else if (setA != null && setB != null)
        {
            if (setA == setB)
            {
                Console.Write(" образует цикл");
                return;
            }

            setA.Union(setB, edge);
            Sets.Remove(setB);
        }
    }

    public Set Find(string vertex)
    {
        return Sets.FirstOrDefault(set => set.Contains(vertex));
    }
}