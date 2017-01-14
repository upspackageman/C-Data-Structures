using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class Node
    {
        public Node lchild;
        public char info;
        public Node rchild;

        public Node(char c)
        {
            info = c;
            lchild = null;
            rchild = null;
        }
    }
}
