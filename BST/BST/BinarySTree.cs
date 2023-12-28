using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BinarySTree
    {
        class Node
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }
        }
        Node root;
        public BinarySTree() { root = null; }
        public BinarySTree(int value) { root = new Node(value); }
        public void insert(int key)
        {
            root = insertRec(root, key);
        }
        Node insertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);
            return root;
        }
        public bool Find(int data)
        {
            Node current = root;
            return FindRec(current, data);
        }
        private bool FindRec(Node current, int data)
        {
            while (current != null)
            {
                if (data < current.key)
                {
                    current = current.left;
                    FindRec(current, data);
                }
                else if (data > current.key)
                {
                    current = current.right;
                    FindRec(current, data);
                }
                else
                    return true;
            }
            return false;
        }
        public void DeleteRec(int data)
        {

        }
        public void inorder()
        {
            inorderRec(root);
        }
        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.Write(root.key + " ");
                inorderRec(root.right);
            }
        }
    }
}
