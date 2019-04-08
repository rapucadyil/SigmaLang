using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaCompiler
{
    public class SynTreeNode
    {
        public string data;
        public string opr;
        public SynTreeNode right;
        public SynTreeNode left;

        public SynTreeNode(string dat, string op)
        {
            data = dat;
            opr = op;
            right = null;
            left = null;
        }

        public void AddRightChild(SynTreeNode add)
        {
            this.right = add;
        }

        public void AddLeftChild(SynTreeNode add)
        {
            this.left = add;
        }
    }


    public class SyntaxTree
    {
        public List<SynTreeNode> nodes;

        public SyntaxTree()
        {
            nodes = new List<SynTreeNode>();
        }

    }
}
