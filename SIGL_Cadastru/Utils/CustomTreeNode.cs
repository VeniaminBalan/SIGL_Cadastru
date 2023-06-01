using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Utils
{
    public enum TreeObjectType
    {
        Point,
        Simple
    }
    public class CustomTreeNode : TreeNode
    {
        public TreeObjectType TreeobjectType { get; set; } = TreeObjectType.Simple;

        public CustomTreeNode(TreeObjectType treeobjectType, string name) : base(name)
        {
            TreeobjectType = treeobjectType;
        }
        public CustomTreeNode( string name) : base(name)
        {

        }
        public CustomTreeNode()
        {

        }

    }
}
