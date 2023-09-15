using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models;

public class Document
{
    public string Denumirea { get; set; }
    public string Nr { get; set; }
    public DateOnly Data { get; set; }
    public string Mentiuni { get; set; }
    public decimal Exemplare { get; set; }
}
