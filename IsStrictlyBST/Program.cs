/*
 You are given a binary tree with integers as its keys. You need to test whether it is a correct binary
search tree. Note that there can be duplicate integers in the tree, and this is allowed. The definition of
the binary search tree in such case is the following: for any node of the tree, if its key is 𝑥, then for any
node in its left subtree its key must be strictly less than 𝑥, and for any node in its right subtree its key
must be greater than or equal to 𝑥. In other words, smaller elements are to the left, bigger elements
are to the right, and duplicates are always to the right. You need to check whether the given binary
tree structure satisfies this condition. You are guaranteed that the input contains a valid binary tree.
That is, it is a tree, and each node has at most two children.
Input Format. The first line contains the number of vertices 𝑛. The vertices of the tree are numbered
from 0 to 𝑛 − 1. Vertex 0 is the root.
The next 𝑛 lines contain information about vertices 0, 1, ..., 𝑛−1 in order. Each of these lines contains
three integers 𝑘𝑒𝑦𝑖, 𝑙𝑒𝑓𝑡𝑖 and 𝑟𝑖𝑔ℎ𝑡𝑖 — 𝑘𝑒𝑦𝑖 is the key of the 𝑖-th vertex, 𝑙𝑒𝑓𝑡𝑖 is the index of the left
child of the 𝑖-th vertex, and 𝑟𝑖𝑔ℎ𝑡𝑖 is the index of the right child of the 𝑖-th vertex. If 𝑖 doesn’t have
left or right child (or both), the corresponding 𝑙𝑒𝑓𝑡𝑖 or 𝑟𝑖𝑔ℎ𝑡𝑖 (or both) will be equal to −1.
Constraints. 0 ≤ 𝑛 ≤ 10^5; −2^31 ≤ 𝑘𝑒𝑦𝑖 ≤ 2^31 − 1; −1 ≤ 𝑙𝑒𝑓𝑡𝑖, 𝑟𝑖𝑔ℎ𝑡𝑖 ≤ 𝑛 − 1. It is guaranteed that the
input represents a valid binary tree. In particular, if 𝑙𝑒𝑓𝑡𝑖 ̸= −1 and 𝑟𝑖𝑔ℎ𝑡𝑖 ̸= −1, then 𝑙𝑒𝑓𝑡𝑖 ̸= 𝑟𝑖𝑔ℎ𝑡𝑖.
Also, a vertex cannot be a child of two different vertices. Also, each vertex is a descendant of the root
vertex. Note that the minimum and the maximum possible values of the 32-bit integer type are allowed
to be keys in the tree — beware of integer overflow!
Output Format. If the given binary tree is a correct binary search tree (see the definition in the problem
description), output one word “CORRECT” (without quotes). Otherwise, output one word “INCORRECT”
(without quotes).
Memory Limit. 512MB.
10
Sample 1.
Input:
3
2 1 2
1 -1 -1
3 -1 -1
Output:
CORRECT
Explanation:
    2
   / \
  1   3
Left child of the root has key 1, right child of the root has key 3, root has key 2, so everything to the
left is smaller, everything to the right is bigger.
Sample 2.
Input:
3
1 1 2
2 -1 -1
3 -1 -1
Output:
INCORRECT
Explanation:
    1
   / \
  2   3
The left child of the root must have smaller key than the root.
11
Sample 3.
Input:
3
2 1 2
1 -1 -1
2 -1 -1
Output:
CORRECT
Explanation:
    2
   / \
  1   2
Duplicate keys are allowed, and they should always be in the right subtree of the first duplicated
element.
Sample 4.
Input:
3
2 1 2
2 -1 -1
3 -1 -1
Output:
INCORRECT
Explanation:
    2
   / \
  2   3
The key of the left child of the root must be strictly smaller than the key of the root.
Sample 5.
Input:
0
Output:
CORRECT
Explanation:
Empty tree is considered correct.
12
Sample 6.
Input:
1
2147483647 -1 -1
Output:
CORRECT
Explanation:
2147483647
The maximum possible value of the 32-bit integer type is allowed as key in the tree.
Sample 7.
Input:
5
1 -1 1
2 -1 2
3 -1 3
4 -1 4
5 -1 -1
Output:
CORRECT
Explanation:
1
 \
  2
   \
    3
     \
      4
       \
        5
The tree doesn’t have to be balanced. We only need to test whether it is a correct binary search tree,
which the tree in this example is.
13
Sample 8.
Input:
7
4 1 2
2 3 4
6 5 6
1 -1 -1
3 -1 -1
5 -1 -1
7 -1 -1
Output:
CORRECT
Explanation:
        4
       / \
      2   6
     / \  /\
    1   3 5 7
This is a full binary tree, and the property of the binary search tree is satisfied in every node.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsStrictlyBST
{
    class Node
    {
        internal int data;
        internal int depth;
        internal Node left;
        internal Node right;
        internal bool processed;
    }

    class Program
    {
        //Check if the Inorder Traversal sorts the tree in ascending order
        //Keep track of the depth of the nodes
        //if the depth of the left node is larger, then it means that the left node is a decendent of the right
        //For any two nodes with equal data, if the left node's depth is larger then it is not a strictly BST
        static bool Traverse(Node root)
        {
            int lastKey = int.MinValue;
            int lastDepth = 0;
            Stack<Node> stack = new Stack<Node>();
            root.depth = 1;
            stack.Push(root);
            Node current;

            while (stack.Count != 0)
            {
                current = stack.Pop();
                if (current.processed == false)
                {
                    current.processed = true;
                    if (current.right != null)
                    {
                        current.right.depth = current.depth + 1;
                        stack.Push(current.right);
                    }
                    stack.Push(current);
                    if (current.left != null)
                    {
                        current.left.depth = current.depth + 1;
                        stack.Push(current.left);
                    }
                }
                else
                {
                    if (lastKey > current.data)
                    {
                        return false;
                    }
                    if(lastKey == current.data && lastDepth > current.depth)
                    {
                        return false;
                    }
                    lastKey = current.data;
                    lastDepth = current.depth;
                }
            }
            return true;
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
            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split(' ').Select(r => int.Parse(r)).ToArray();
                Tree[i].data = tokens[0];
                if (tokens[1] != -1)
                    Tree[i].left = Tree[tokens[1]];
                if (tokens[2] != -1)
                    Tree[i].right = Tree[tokens[2]];
            }

            if (n == 0 || Traverse(Tree[0]))
            {
                Console.WriteLine("CORRECT");
            }
            else
            {
                Console.WriteLine("INCORRECT");
            }

            //Console.ReadLine();
        }
    }
}
