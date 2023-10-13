using SIGL_Cadastru.Repo.Models;
using System.ComponentModel;

namespace SIGL_Cadastru.Views
{
    public partial class UC_DocumentsView : UserControl
    {
        private List<Document> documents = new();
        public UC_DocumentsView(List<Document> documents)
        {

            this.documents = documents;
            InitializeComponent();
        }

        public List<Document> GetDocumente()
        {
            var documente = new List<Document>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Document? doc = row.DataBoundItem as Document;

                if (doc is not null)
                {
                    documente.Add(doc);
                }
            }

            return documente;
        }

        private void UC_DocumentsView_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BindingList<Document>(documents);
        }
    }
}
