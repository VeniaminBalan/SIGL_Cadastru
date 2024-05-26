using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.ValueObjects;

public class NrCerere
{
    public int Year { get; set; }
    public int Index { get; set; }

    private NrCerere() { }
    public NrCerere(int year, int index) 
    {
        Year= year;
        Index= index;
    }

    public string ToString(char separator)
        => $"{Year % 100}{separator}{Index.ToString("0000")}";
}
