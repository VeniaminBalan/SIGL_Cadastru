
namespace SIGL_Cadastru.Utils
{
    public enum TreeObjectType
    {
        Point,
        Regular,
        Price
    }
    public class CustomTreeNode : TreeNode
    {
        public TreeObjectType TreeobjectType { get; set; } = TreeObjectType.Regular;

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
