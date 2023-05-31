using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public class Model : IModel
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Model() 
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }
    }
}
