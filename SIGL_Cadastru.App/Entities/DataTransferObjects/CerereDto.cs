using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Entities
{
    public class CerereDto
    {
        public Guid Id { get; set; }
        public string Client { get; set; }
        public string Executant { get; set; }
        public string Responsabil { get; set; }
        public string NrCadastral { get; set; }
        public DateOnly ValabilDeLa { get; set; }
        public DateOnly ValabilPanaLa { get; set; }
        public DateOnly Prelungit { get; set; }
        public Status StareaCererii { get; set; }
        public DateOnly LaReceptie { get; set; }
        public DateOnly Eliberat { get; set; }
        public DateOnly Respins { get; set; }

        public override string ToString()
        {
            return new string($"{Id} \n {Client} \n {Executant} \n {Responsabil} \n {NrCadastral}");
        }
    }
}
