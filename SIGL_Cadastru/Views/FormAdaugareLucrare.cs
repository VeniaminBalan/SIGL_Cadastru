using SIGL_Cadastru.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public event EventHandler<AdaugareLucrareEventArgs> SubmitButtonPressed;


        private int? pret;
        private int puncte = 1;
        private int suma = 0;
        private string path;

        public FormAdaugareLucrare()
        {
            InitializeComponent();
            InitTreeView();
            panel_lucrare.Enabled = false;
            panel_lucrare.Visible = false;
        }

        private void InitTreeView()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlNode;

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Resources\Nomenclatura.xml");
            string sFilePath = Path.GetFullPath(sFile);

            FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);

            xmlNode = xmldoc.ChildNodes[1];
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
            TreeNode tNode;
            tNode = treeView1.Nodes[0];

            AddNode(xmlNode, tNode);

        }
        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
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
                        inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Regular, attribute));

                    } else if (xNode.Name == "Price")
                    {
                        try
                        {
                            var attribute = xNode.Attributes[0];
                            if (attribute.Name == "puncte")
                            {
                                //DisplayPointSelector();
                                inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Point, "Puncte"));

                            }
                            else
                            {
                                var str = attribute.Value.ToString() + " zile";
                                inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Price, str));
                            }
                        }
                        catch (Exception ex)
                        {
                            inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Price, "Pret"));
                        }

                    }
                    else
                        inTreeNode.Nodes.Add(new CustomTreeNode(TreeObjectType.Regular, xNode.Name));


                    tNode = inTreeNode.Nodes[i];
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
        private void HidePointSelector()
        {
            groupBoxPuncte.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (GetSuma() == 0)
            {
                MessageBox.Show("Selectati lucraraea");
            }
            else 
            {
                var text = labelNodeSelected.Text + "\n" + "Suma: " + GetSuma();
                DialogResult dialogResult = MessageBox.Show(text, "Adaugare Lucrare", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SubmitButtonPressed?.Invoke(this, new AdaugareLucrareEventArgs
                    {
                        lucrare = labelNodeSelected.Text,
                        suma = GetSuma()
                    });
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            labelNodeSelected.Text = "";
            string txt = e.Node.FullPath;
            var index = txt.IndexOf(@"\");
            if (index != -1) 
            {
                index++;
                SetPath(txt.Substring(index, txt.Length - index));
            }else
                SetPath("");

            CustomTreeNode? node = e.Node as CustomTreeNode;
            if (node == null) return;


            switch (node.TreeobjectType)
            {
                case TreeObjectType.Point:
                    DisplayPointSelector();
                    SetPriceValue(node);
                    break;
                case TreeObjectType.Regular:
                    HidePointSelector();
                    SetPret(null);
                    break;
                case TreeObjectType.Price:
                    SetPriceValue(node);
                    HidePointSelector();
                    break;
                default:
                    break;
            }

        }


        private void SetPriceValue(CustomTreeNode node) 
        {
            var child = node.FirstNode;
            try
            {
                int price = Convert.ToInt32(child.Text);
                puncte = 1;
                SetPret(price);
            }
            catch (Exception)
            {
                SetPret(0);
            }
        }

        private void SetPret(int ?_pret) 
        {
            pret = _pret;
            SetSuma();
        }

        private void SetSuma() 
        {
            if (pret == null)
            {
                this.suma = 0;
                label_suma.Text = "";
            }
            else 
            {
                this.suma = (int)pret * puncte;
                label_suma.Text = suma.ToString();
            }
                
        }

        private int GetSuma() 
        {
            return this.suma;
        }


        public int? GetPret() 
        {
            return pret;
        }

        private AdaugareLucrareEventArgs GetEventArgs() 
        {
            if(GetPret() != null) 
            {

            }
            return null;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {


        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void onPuncteChanhed()
        {

        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.puncte = Convert.ToInt32(maskedTextBox1.Text);
                DisplayPath(": " + puncte.ToString());

            }
            catch (Exception)
            {
                DisplayPath();
                this.puncte = 1;
            }
            SetSuma();

        }

        private void SetPath(string path) 
        {
            this.path = path;
            DisplayPath();
        }

        private string GetPath() 
        {
            return this.path;
        }

        private void DisplayPath(string option ="") 
        {
            labelNodeSelected.Text = path + option;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel_lucrare.Enabled = true;
                panel_lucrare.Visible = true;
            }
            else 
            {
                panel_lucrare.Enabled = false;
                panel_lucrare.Visible = false;
            }


        }
    }

    public class AdaugareLucrareEventArgs : EventArgs
    {
        public int suma;
        public string lucrare;
    }
}
