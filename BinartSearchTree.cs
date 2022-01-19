using System;

public class BinarySearchTree
{
    /* Class containing left and right
    child of current node and key value*/
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

    // Root of BST
    Node root;

    // Constructor
    BinarySearchTree() { root = null; }

    // this method return the minimum value in the tree
    int MinValue(Node root)
    {
        int minValue = root.key;
        while (root.left != null)
        {
            minValue = root.left.key;
            root = root.left;
        }
        return minValue;
    }

    // This method mainly calls DeleteRec()
    void DeleteKey(int key) { root = DeleteRec(root, key); }

    /* A recursive function to
      delete an existing key in BST
     */

    Node DeleteRec(Node root, int key)
    {
        /* Base Case: If the tree is empty */
        if (root == null)
            return root;

        /* Otherwise, recur down the tree */
        if (key < root.key)
            root.left = DeleteRec(root.left, key);
        else if (key > root.key)
            root.right = DeleteRec(root.right, key);

        // if key is same as root's key, then This is the
        // node to be deleted
        else
        {
            // node with only one child or no child
            if (root.left == null)
                return root.right;

            else if (root.right == null)
                return root.left;

            // node with two children: Get the
            // inorder successor (smallest
            // in the right subtree)
            root.key = MinValue(root.right);

            // Delete the inorder successor
            root.right = DeleteRec(root.right, root.key);
        }
        return root;
    }


    // This method mainly calls insertRec()
    void Insert(int key) { root = InsertRec(root, key); }

    /* A recursive function to insert a new key in BST */
    Node InsertRec(Node root, int key)
    {

        /* If the tree is empty, return a new node */
        if (root == null)
        {
            root = new Node(key);
            return root;
        }

        /* Otherwise, recur down the tree */
        if (key < root.key)
            root.left = InsertRec(root.left, key);
        else if (key > root.key)
            root.right = InsertRec(root.right, key);

        /* return the (unchanged) node pointer */
        return root;
    }

    // This method mainly calls InorderRec()
    void Inorder() { InorderRec(root); }

    // A utility function to do inorder traversal of BST
    void InorderRec(Node root)
    {
        if (root != null)
        {
            InorderRec(root.left);
            Console.Write(root.key + " ");
            InorderRec(root.right);
        }
    }

    // Driver code
    public static void Main(String[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();

        /* Let us create following BST
                 50
                /  \
              30    70
             / \    / \
            20 40  60 80 */
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);


        Console.WriteLine(
            "Inorder traversal of the given tree");
        tree.Inorder();

        Console.WriteLine("\nDelete 20");
        tree.DeleteKey(20);
        Console.WriteLine(
            "Inorder traversal of the modified tree");
        tree.Inorder();

        Console.WriteLine("\nDelete 30");
        tree.DeleteKey(30);

        Console.WriteLine(
            "Inorder traversal of the modified tree");
        tree.Inorder();

        Console.WriteLine("\nDelete 50");
        tree.DeleteKey(50);

        Console.WriteLine(
            "Inorder traversal of the modified tree");
        tree.Inorder();
    }
}