using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class Node
    {
        public Node lchild;
        public int info;
        public Node rchild;
        public int balance;

        public Node(int i)
        {
            info = i;
            balance = 0;
            lchild = null;
            rchild = null;
        }

    }
}
