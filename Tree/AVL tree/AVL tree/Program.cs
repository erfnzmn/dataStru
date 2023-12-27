using System.Data;
using System.Xml.Linq;

public class AVLtree
{
    public class AVLNode
    { 
        public int height;
        public int data;
        public AVLNode rightroot;
        public AVLNode leftroot;
        public AVLNode(int d)
        {
            this.data = d;
        }
        public string ToString()
        {
           return "value:" + " " + this.data;  
        }
    }
    private AVLNode root;
    public void Insertroot(int data)
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
            root.leftroot = insert(root.leftroot, data);
        }
        else
        {
            root.rightroot = insert(root.rightroot, data);
        }
        
        var balance = Balanced(root);
        if(isLeftHeavy(root))
        {
            Console.WriteLine(root.data+" is Left Heavy..");
        }
        else if(isRightHeavy(root))
        {
            Console.WriteLine(root.data+" is Right Heavy..");
        }

        return root;
    }
    AVLNode minValueNode(AVLNode node)
    {
        AVLNode temp = node;
        while (temp.leftroot != null)
            temp = temp.leftroot;

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
            root.leftroot = DeleteNode(root.leftroot, data);
        }
        else if(data>root.data)
        {
            root.rightroot = DeleteNode(root.rightroot, data);
        }
        else
        {
            if ((root.leftroot == null) || (root.rightroot == null))
            {
                AVLNode temp = null;
                if (temp == root.leftroot)
                {
                    temp = root.rightroot;
                }
                else
                    temp = root.leftroot;
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
                AVLNode temp = minValueNode(root.rightroot);
                root.data = temp.data;
                root.rightroot = DeleteNode(root.rightroot, temp.data);
            }
        }
        if(root==null)
        {
            return root;
        }
        root.height = Math.Max(height(root.leftroot), height(root.rightroot)) + 1;

        int balance = Balanced(root);
        if(isLeftHeavy(root) && Balanced(root.leftroot)>=0)
        {
            return RotationRight(root);
        }
        else if(isLeftHeavy(root)&&Balanced(root.leftroot)<0)
        {
            root.leftroot = RotationLeft(root.leftroot);
            return RotationRight(root);
        }
        else if(isRightHeavy(root) && Balanced(root.rightroot)<=0)
        {
            return RotationLeft(root);
        }
        else if(isRightHeavy(root)&&Balanced(root.rightroot)>0)
        {
            root.rightroot = RotationRight(root.rightroot);
            return RotationLeft(root);
        }
        return root;
    }
    public AVLNode RotationLeft(AVLNode root)
    {
        var newRoot = root.rightroot;
        root.rightroot = newRoot.leftroot;
        newRoot.leftroot = root;
        setheight(root);
        setheight(newRoot);

        return newRoot;
    }
    public AVLNode RotationRight(AVLNode root)
    {
        var newRoot = root.leftroot;
        root.leftroot = newRoot.rightroot;
        newRoot.rightroot = root;
        setheight(root);
        setheight(newRoot);
        return newRoot;
    }
    public void preorder(AVLNode root)
    {
        if(root==null)
        {
            return;
        }
        Console.WriteLine(root.data);
        preorder(root.leftroot);
        preorder(root.rightroot);
    }
    public void inorder(AVLNode root)
    {
        if (root == null)
        {
            return; 
        }
        inorder(root.leftroot);
        Console.WriteLine(root);
        inorder(root.rightroot);
    }
    public void postorder(AVLNode root)
    {
        if(root==null)
        {
            return;
        }
        postorder(root.leftroot);
        postorder(root.rightroot);
        Console.WriteLine(root);
    }
   public static bool Find(AVLNode root,int data)
    {
        if (root == null)
            return false;
        else if (root.data == data)
            return true;
        else if (root.data < data)
            return Find(root.rightroot, data);
        else 
            return Find(root.leftroot, data);
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
        node.height = Math.Max(height(node.leftroot), height(node.rightroot)) + 1;
    }
    private bool isRightHeavy(AVLNode node)
    {
        return Balanced(node) <-1;
    }
    private bool isLeftHeavy(AVLNode node)
    {
        return Balanced(node) >1; 
    }
    private int Balanced(AVLNode node)
    {
        if (node == null)
            return 0;
        else
        {
            return height(node.leftroot) - height(node.rightroot);
        }
    }
    public AVLNode balance(AVLNode node)
    {
        if(isLeftHeavy(root))
        {
            if(Balanced(root.leftroot)<0)
            {
                root.leftroot=RotationLeft(root.leftroot);
                return RotationRight(root);
            }
        }
        else if(isRightHeavy(root))
        {
            if(Balanced(root.rightroot)>0)
            {
                root.rightroot=RotationRight(root.rightroot);
                return RotationLeft(root);
            }
        }
        return root;
    }
}