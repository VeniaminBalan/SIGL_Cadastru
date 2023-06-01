using SIGL_Cadastru.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SIGL_Cadastru.Views
{
    public partial class FormAdaugareLucrare : Form
    {
        private int ?pret;

        public FormAdaugareLucrare()
        {
            InitializeComponent();
            InitTreeView();
        }

        private void InitTreeView() 
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlNode;

            FileStream fs = new FileStream(@"E:\PC\Projects\consult-trading\SIGL_Cadastru\SIGL_Cadastru\Resources\Nomenclatura.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            xmlNode = xmldoc.ChildNodes[1];
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
            CustomTreeNode tNode;
            tNode = (CustomTreeNode)treeView1.Nodes[0];

            AddNode(xmlNode, tNode);

        }
        private void AddNode(XmlNode inXmlNode, CustomTreeNode inTreeNode) 
        {
            XmlNode xNode;
            CustomTreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name == "Cadastru" || xNode.Name == "Suprafata")
                    {
                        string attribute = xNode.Attributes[0].Value.ToString();
                        //treeNodeCustom.AddChild(new TreeObject {Name=xNode.Name, Type=TreeObjectType.Simple });
                        inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Simple,attribute));

                    } else if(xNode.Name == "Price") 
                    {
                        try 
                        {
                            var attribute = xNode.Attributes[0];
                            if (attribute.Name == "puncte")
                            {
                                //DisplayPointSelector();
                                inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Point, "Pret"));
                               
                            }
                            else
                            {
                                var str = attribute.Value.ToString() + " zile";
                                inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Simple, str));
                            }
                        }
                        catch(Exception ex) 
                        {
                            inTreeNode.Nodes.Add("Pret");
                        }

                    }
                    else
                        inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Simple,xNode.Name));

                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }

        private void DisplayPointSelector() 
        {
            groupBoxPuncte.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            labelNodeSelected.Text = e.Node.FullPath;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string txt = e.Node.Text;

            CustomTreeNode node = e.Node as CustomTreeNode;
            if (node.TreeobjectType == TreeObjectType.Point)
            {
                DisplayPointSelector();
            }

            try 
            {
                int value = Convert.ToInt32(txt);
                SetPret(value);
                
                
            }catch(Exception ex) 
            {

                SetPret(null);
            }

        }

        private void SetPret(int ?_pret) 
        {
            pret = _pret;
            if (pret == null) 
            {
                label_suma.Text = "";
            }else
                label_suma.Text = pret.ToString();
        }

        public int? GetPret() 
        {
            return pret;
        }
        
    }
}
