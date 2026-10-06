using UnityEngine;

namespace Midterm
{
    public class TreeSample : MonoBehaviour
    {
        TreeNode root = null;

        void Start()
        {
            CreateTree();

            // - Find the TreeNode with the highest value
            Debug.Log(root.FindMaximum().Data);
        }

        void CreateTree()
        {
            root = new TreeNode(7);

            TreeNode nodeA = new TreeNode(4);
            TreeNode nodeB = new TreeNode(3);
            TreeNode nodeC = new TreeNode(2);
            TreeNode nodeD = new TreeNode(10);

            // - leaf nodes further down  
            nodeC.AddChild(nodeD);
            nodeB.AddChild(nodeA);

            // - adding the root children nodes
            root.AddChild(nodeC);
            root.AddChild(nodeB);
        }
    }
}
