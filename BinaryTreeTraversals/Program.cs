/*
You are given a rooted binary tree. Build and output its in-order, pre-order and post-order traversals.
Input Format. The first line contains the number of vertices 𝑛. The vertices of the tree are numbered
from 0 to 𝑛 − 1. Vertex 0 is the root.
The next 𝑛 lines contain information about vertices 0, 1, ..., 𝑛−1 in order. Each of these lines contains
three integers 𝑘𝑒𝑦𝑖, 𝑙𝑒𝑓𝑡𝑖 and 𝑟𝑖𝑔ℎ𝑡𝑖 — 𝑘𝑒𝑦𝑖 is the key of the 𝑖-th vertex, 𝑙𝑒𝑓𝑡𝑖 is the index of the left
child of the 𝑖-th vertex, and 𝑟𝑖𝑔ℎ𝑡𝑖 is the index of the right child of the 𝑖-th vertex. If 𝑖 doesn’t have
left or right child (or both), the corresponding 𝑙𝑒𝑓𝑡𝑖 or 𝑟𝑖𝑔ℎ𝑡𝑖 (or both) will be equal to −1.
Constraints. 1 ≤ 𝑛 ≤ 10^5; 0 ≤ 𝑘𝑒𝑦𝑖 ≤ 10^9; −1 ≤ 𝑙𝑒𝑓𝑡𝑖, 𝑟𝑖𝑔ℎ𝑡𝑖 ≤ 𝑛 − 1. It is guaranteed that the input
represents a valid binary tree. In particular, if 𝑙𝑒𝑓𝑡𝑖 ̸= −1 and 𝑟𝑖𝑔ℎ𝑡𝑖 ̸= −1, then 𝑙𝑒𝑓𝑡𝑖 ̸= 𝑟𝑖𝑔ℎ𝑡𝑖. Also,
a vertex cannot be a child of two different vertices. Also, each vertex is a descendant of the root vertex.
Output Format. Print three lines. The first line should contain the keys of the vertices in the in-order
traversal of the tree. The second line should contain the keys of the vertices in the pre-order traversal
of the tree. The third line should contain the keys of the vertices in the post-order traversal of the tree.
Memory Limit. 512MB.
Sample 1.
Input:
5
4 1 2
2 3 4
5 -1 -1
1 -1 -1
3 -1 -1
Output:
1 2 3 4 5
4 2 1 3 5
1 3 2 5 4
Explanation:
    4
    /\
   2  5
  /\
 1 3

Sample 2.
Input:
10
0 7 2
10 -1 -1
20 -1 6
30 8 9
40 3 -1
50 -1 -1
60 1 -1
70 5 4
80 -1 -1
90 -1 -1
Output:
50 70 80 30 90 40 0 20 10 60
0 70 50 40 30 80 90 20 60 10
50 80 90 30 40 70 10 60 20 0
Explanation:
        0
       / \
     70   20
     /\     \
   50  40    60
       /     /
     30     10
     /\
    80 90

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeTraversals
{
    class Node
    {
        internal int data;
        internal Node left;
        internal Node right;
        internal bool processed;
    }

    class Program
    {
        static StringBuilder Traverse(Node root, string order)
        {
            StringBuilder print = new StringBuilder("");
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            Node current;
            
            while(stack.Count != 0)
            {
                current = stack.Pop();
                if (current.processed == false)
                {
                    switch (order)
                    {
                        case "inorder":
                            current.processed = true;
                            if (current.right != null)
                                stack.Push(current.right);
                            stack.Push(current);
                            if (current.left != null)
                                stack.Push(current.left);
                            break;
                        case "preorder":
                            current.processed = true;
                            if (current.right != null)
                                stack.Push(current.right);
                            if (current.left != null)
                                stack.Push(current.left);
                            stack.Push(current);
                            break;
                        case "postorder":
                            current.processed = true;
                            stack.Push(current);
                            if (current.right != null)
                                stack.Push(current.right);
                            if (current.left != null)
                                stack.Push(current.left);
                            break;
                    }
                }
                else
                {
                    print.Append(current.data.ToString() + " ");
                    current.processed = false;
                }
            }
            return print;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] tokens;
            Node[] Tree = new Node[n];
            for (int i = 0; i < n; i++)
            {
                Tree[i] = new Node();
            }
            for (int i=0;i<n;i++)
            {
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                Tree[i].data = tokens[0];
                if (tokens[1] != -1)
                    Tree[i].left = Tree[tokens[1]];
                if (tokens[2] != -1)
                    Tree[i].right = Tree[tokens[2]];
            }
            
            Console.WriteLine(Traverse(Tree[0], "inorder"));
        
            Console.WriteLine(Traverse(Tree[0], "preorder"));

            Console.WriteLine(Traverse(Tree[0], "postorder"));

            //Console.ReadLine();
        }
    }
}
