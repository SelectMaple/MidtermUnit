using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    public class TreeNode 
    {
        public int Data;
        public List<TreeNode> children = new List<TreeNode>();

        public TreeNode(int _data)
        {
            Data = _data;
        }

        public void AddChild(TreeNode newChild)
        {
            children.Add(newChild);
        }

        public TreeNode FindMaximum()
        {
            TreeNode targetNode = this;

            if (children.Count > 0)
            {
                foreach (TreeNode child in children)
                {
                    if (child.Data > Data)
                    {
                        targetNode = child.FindMaximum();
                    }
                }
            }
            else
            {
                targetNode = this;

            }

            return targetNode;
        }
    }
}
