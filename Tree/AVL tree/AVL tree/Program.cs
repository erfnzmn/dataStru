using System.Data;
using System.Xml.Linq;

public class AVLtree
{
    public class AVLNode
    { 
        public int height;
        public int data;
        public AVLNode right;
        public AVLNode left;
        public AVLNode(int d)
        {
            this.data = d;
        }
    }
    private AVLNode root;
    public void Insert(int data)
    {
       root = insert(root, data);
    }
    private AVLNode insert(AVLNode root,int data)
    {
        if (root == null)
        {
            return new AVLNode(data);
        }
        else if(data<root.data)
        {
            root.left = insert(root.left, data);
        }
        else
        {
            root.right = insert(root.right, data);
        }
        setheight(root);
        return balance(root);
    }
    AVLNode minValueNode(AVLNode node)
    {
        AVLNode temp = node;
        while (temp.left != null)
            temp = temp.left;

        return temp;
    }
    public AVLNode DeleteNode(AVLNode root,int data)
    {
        if(root==null)
        {
            return root;
        }
        if(data<root.data)
        {
            root.left = DeleteNode(root.left, data);
        }
        else if(data>root.data)
        {
            root.right = DeleteNode(root.right, data);
        }
        else
        {
            if ((root.left == null) || (root.right == null))
            {
                AVLNode temp = null;
                if (temp == root.left)
                {
                    temp = root.right;
                }
                else
                    temp = root.left;
                if (temp == null)
                {
                    temp = root;
                    root = null;
                }
                else
                    temp = root;
            }
            else
            {
                AVLNode temp = minValueNode(root.right);
                root.data = temp.data;
                root.right = DeleteNode(root.right, temp.data);
            }
        }
        if(root==null)
        {
            return root;
        }
        root.height = Math.Max(height(root.left), height(root.right)) + 1;

        return balance(root);
        if(isLeftHeavy(root) && BalancedFactor(root.left) >=0)
        {
            return RotationRight(root);
        }
        else if(isLeftHeavy(root)&& BalancedFactor(root.left) <0)
        {
            root.left = RotationLeft(root.left);
            return RotationRight(root);
        }
        else if(isRightHeavy(root) && BalancedFactor(root.right) <=0)
        {
            return RotationLeft(root);
        }
        else if(isRightHeavy(root)&& BalancedFactor(root.right) >0)
        {
            root.right = RotationRight(root.right);
            return RotationLeft(root);
        }
        return root;
    }
    public AVLNode RotationLeft(AVLNode root)
    {
        var newRoot = root.right;
        root.right = newRoot.left;
        newRoot.left = root;
        setheight(root);
        setheight(newRoot);

        return newRoot;
    }
    public AVLNode RotationRight(AVLNode root)
    {
        var newRoot = root.left;
        root.left = newRoot.right;
        newRoot.right = root;
        setheight(root);
        setheight(newRoot);
        return newRoot;
    }
   public static bool Find(AVLNode root,int data)
    {
        if (root == null)
            return false;
        else if (root.data == data)
            return true;
        else if (root.data < data)
            return Find(root.right, data);
        else 
            return Find(root.left, data);
    }
    private int height(AVLNode node)
    {
        if (node == null)
            return -1;
        else
            return node.height;
    }
    private void setheight(AVLNode node)
    {
        node.height = Math.Max(height(node.left), height(node.right)) + 1;
    }
    private bool isRightHeavy(AVLNode node)
    {
        return BalancedFactor(node) <-1;
    }
    private bool isLeftHeavy(AVLNode node)
    {
        return BalancedFactor(node) >1; 
    }
    private int BalancedFactor(AVLNode node)
    {
        if (node == null)
            return 0;
        else
            return height(node.left) - height(node.right);
    }
    public AVLNode balance(AVLNode node)
    {
        if(isLeftHeavy(root))
        {
            if(BalancedFactor(root.left) <0)
            {
                root.left=RotationLeft(root.left);
                return RotationRight(root);
            }
        }
        else if(isRightHeavy(root))
        {
            if(BalancedFactor(root.right) >0)
            {
                root.right = RotationRight(root.right);
                return RotationLeft(root);
            }
        }
        return root;
    }
    public void inorder(AVLNode root)
    {
        if (root == null)
        {
            return;
        }
        inorder(root.left);
        Console.WriteLine(root);
        inorder(root.right);
    }
    public void PrintAVL()
    {
        if (root == null)
        {
            Console.WriteLine("AVL is empty");
            return;
        }
        Console.WriteLine("Printing AVL:");
        inorder(root);
    }
}