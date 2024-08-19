using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bfs : MonoBehaviour
{
    public class TreeNode
    {
        public int Value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode (int value)
        {
            Value = value;
            left = null;
            right = null;
        }
    }

    public TreeNode root;

    public void Start()
    {
        root = new TreeNode(1);

        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(6);
        root.left.left.left = new TreeNode(7);

        root.right.right.right = new TreeNode(8);



        TreeNode deepestLeaf = FindDeepLeaf(root);

        if(deepestLeaf != null)
        {
            Debug.Log($"{deepestLeaf.Value}");
        }
        else
        {
            Debug.Log("Tree empty");
        }
    }

     TreeNode FindDeepLeaf(TreeNode root)
    {
        if (root == null)
            return null;

        Queue<TreeNode> treeQueue = new Queue<TreeNode>();

        treeQueue.Enqueue(root);

        TreeNode currentNode = null;

        while(treeQueue.Count > 0)
        {
            currentNode = treeQueue.Dequeue();

            if(currentNode.left != null)
                treeQueue.Enqueue(currentNode.left);

            if (currentNode.right != null)
                treeQueue.Enqueue(currentNode.right);
        }

        return currentNode;
        
    }
}


