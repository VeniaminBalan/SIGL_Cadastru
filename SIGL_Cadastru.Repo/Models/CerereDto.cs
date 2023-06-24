using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public enum Status
    {
        Inlucru,
        LaReceptie,
        Eliberat,
        Respins
    }
    public class CerereDto : Model
    {
        public PersoanaDto Client { get; set; }
        public PersoanaDto Executant { get; set; }
        public PersoanaDto Responsabil { get; set; }
        IList<LucrareDto> Lucrari { get; set; }
        public string NrCadastral { get; set; }
        public DateOnly ValabilDeLa { get; set; }
        public DateOnly ValabilPanaLa { get; set; }
        public DateOnly Prelungit { get; set; }
        public int CostTotal { get; set; }
        public Status StareaCererii { get; set; }
        public DateOnly LaReceptie { get; set; }
        public DateOnly Eliberat { get; set; }
        public DateOnly Respins { get; set; }

        // TO DO !!!
        // File Management

    }
}
