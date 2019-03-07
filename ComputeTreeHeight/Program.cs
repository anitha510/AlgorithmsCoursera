/*
You are given a description of a rooted tree. Your task is to compute and output its height. Recall
that the height of a (rooted) tree is the maximum depth of a node, or the maximum distance from a
leaf to the root. You are given an arbitrary tree, not necessarily a binary tree.
Input Format. The first line contains the number of nodes 𝑛. The second line contains 𝑛 integer numbers
from −1 to 𝑛 − 1 — parents of nodes. If the 𝑖-th one of them (0 ≤ 𝑖 ≤ 𝑛 − 1) is −1, node 𝑖 is the root,
otherwise it’s 0-based index of the parent of 𝑖-th node. It is guaranteed that there is exactly one root.
It is guaranteed that the input represents a tree.
Constraints. 1 ≤ 𝑛 ≤ 105.
Output Format. Output the height of the tree.
Sample 1.
Input:
5
4 -1 4 1 1
Output:
3
The input means that there are 5 nodes with numbers from 0 to 4, node 0 is a child of node 4, node 1
is the root, node 2 is a child of node 4, node 3 is a child of node 1 and node 4 is a child of node 1. To
see this, let us write numbers of nodes from 0 to 4 in one line and the numbers given in the input in
the second line underneath:
0 1 2 3 4
4 -1 4 1 1
Now we can see that the node number 1 is the root, because −1 corresponds to it in the second line.
Also, we know that the nodes number 3 and number 4 are children of the root node 1. Also, we know
that the nodes number 0 and number 2 are children of the node 4.
root 1
     /\
    3  4
       /\
      0  2
The height of this tree is 3, because the number of vertices on the path from root 1 to leaf 2 is 3.
Sample 2.
Input:
5
-1 0 4 0 3
Output:
4
Explanation:
The input means that there are 5 nodes with numbers from 0 to 4, node 0 is the root, node 1 is a child
of node 0, node 2 is a child of node 4, node 3 is a child of node 0 and node 4 is a child of node 3. The
height of this tree is 4, because the number of nodes on the path from root 0 to leaf 2 is 4.
root  0
     / \
    1   3
        |
        4
        |
        2
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputeTreeHeight
{
    class Node
    {
        internal int index;
        internal int parent_index;
        internal int level;
        internal List<Node> children;

        internal Node(int i, int p)
        {
            index = i;
            parent_index = p;
            children = new List<Node>();
        }
    }

    class Program
    {
        static int BuildTree(int n, int[] p, out Node[] nodes)
        {
            nodes = new Node[n];
            int root = -1;

            //Allocate nodes
            for(int i=0;i<n;i++)
            {
                nodes[i] = new Node(i, p[i]);
            }
            for (int i = 0; i < n; i++)
            {
                if (p[i] == -1)
                    root = i;
                else
                    nodes[p[i]].children.Add(nodes[i]);
            }
            return root;
        }
        static int GetTreeHeight(int root, Node[] nodes)
        {
            Node current;

            if (root < 0 || root >= nodes.Length)
                return 0;
            else if (nodes[root].children.Count == 0)
                return 1;

            Queue<Node> q = new Queue<Node>();
            nodes[root].level = 1;
            q.Enqueue(nodes[root]);

            do
            {
                current = q.Dequeue();
                if (current.children.Count > 0)
                {
                    foreach(Node child in current.children)
                    {
                        child.level = current.level + 1;
                        q.Enqueue(child);
                    }
                }
            } while (q.Count != 0);
            
            return current.level;
        }

        static int PrintTree(int root, Node[] nodes)
        {
            int max_height = 0, child_height = 0;
            if (root < 0 || root >= nodes.Length)
                return 0;
            else if (nodes[root].children.Count == 0)
                return 1;
            
            foreach (Node child in nodes[root].children)
            {
                Console.Write(child.index.ToString() + ' ');
            }
            Console.WriteLine();
            
            foreach (Node child in nodes[root].children)
            {
                child_height = GetTreeHeight(child.index, nodes);
                max_height = (child_height > max_height) ? child_height : max_height;
                Console.Write('\t');
            }
            return max_height + 1;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] parent_indexes = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
            Node[] nodes;

            int root = BuildTree(n, parent_indexes, out nodes);

            //Console.WriteLine(root.ToString());
            Console.WriteLine(GetTreeHeight(root, nodes).ToString());

            //Console.ReadLine();
        }
    }
}
