using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Day12
{
    public class Input
    {
        public string Cave1 { get; }
        public string Cave2 { get; }

        public Input(string[] caveInput)
        {
            if (caveInput.Length > 2)
                throw new ArgumentOutOfRangeException(nameof(caveInput));

            Cave1 = caveInput[0];
            Cave2 = caveInput[1];

        }
    }

    public enum CaveTypes
    {
        Invalid,
        Large,
        Small
    }

    public class CaveSystem : ICollection
    {
        public List<Node> Nodes { get; set; }

        public IEnumerator GetEnumerator()
        {
            foreach (var node in Nodes)
            {
                yield return node;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count => Nodes.Count;
        public bool IsSynchronized { get; private set; } = false;
        public object SyncRoot { get; private set; } = null;

        public void Add(Node obj)
        {
            Nodes.Add(obj);
        }

        public bool Contains(string name)
        {
            foreach (Node n in Nodes)
            {
                if (n.Name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public class Connection
    {
        public CaveTypes CaveType { get; set; }
        public string Name { get; set; }
    }
    public class Node
    {
        public CaveTypes CaveType { get; set; }
        public string Name { get; set; }
        public List<Node> Connections { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Input> list = ReadInput();

            Part1(list);
        }

        private static void Part1(List<Input> list)
        {
            CaveSystem caves = new();
            Stack nodes = new();
            List<string> visitedSmallCaves = new();
            foreach (var input in list.FindAll(o => o.Cave1 == "start" || o.Cave2 == "start"))
            {
                
            }
            
            
            
            

        }

        private static List<Input> ReadInput()
        {
            List<Input> list = new();
            var lines = File.ReadAllLines("./input-test.txt");

            foreach (var line in lines)
            {
                var temp = line.Split('-');
                list.Add(new(temp));
            }

            return list;
        }
    }
}