using System;
using System.Collections.Generic;

namespace BInary_tree_Nearest_Right_Node_in_the_same_level
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(10);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(7);
            root.left.right = new TreeNode(8);
            root.right.left = new TreeNode(9);
            root.right.right = new TreeNode(4);
            root.left.right.left = new TreeNode(2);
            root.right.left.right = new TreeNode(11);

            Console.WriteLine(FindNearestRightNode(root, new TreeNode(4))?.val);
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        static TreeNode FindNearestRightNode(TreeNode root, TreeNode u)
        {
            if (root == null || u == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool found = false;
            // this flag is to identify the level last node, 
            //when this is true which means in the same level there are no more nodes and we can return null as the nearest right node
            bool levelLastNode = false;
            while (queue.Count > 0 && !levelLastNode)
            {
                int count = queue.Count;
                // below traversal is for each level.
                while(count-- > 0)
                {
                    TreeNode node = queue.Dequeue();
                    if (found) return node;
                    if (node.val == u.val)
                    {
                        found = true;
                        levelLastNode = count == 0;
                    }

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return null;
        }
    }
}
