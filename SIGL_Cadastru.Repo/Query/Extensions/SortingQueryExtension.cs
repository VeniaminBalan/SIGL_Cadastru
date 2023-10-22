using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Query.Extensions
{
    internal static class SortingQueryExtension
    {
        public static IQueryable<Cerere> Sort(this IQueryable<Cerere> query, SortQueryParams sortQuery) 
        {
            if(sortQuery is null)
                return query;


            var sortColumn = sortQuery.SortingColumn.Replace(" ", "").ToLower();

            switch (sortColumn) 
            {
                case "valabilpanala":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.ValabilPanaLa);
                    else
                        return query.OrderByDescending(c => c.ValabilPanaLa);

                case "valabildela":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.ValabilDeLa);
                    else
                        return query.OrderByDescending(c => c.ValabilDeLa);

                case "nr":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.Nr);
                    else
                        return query.OrderByDescending(c => c.Nr);

                case "executent":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.Executant);
                    else
                        return query.OrderByDescending(c => c.Executant);

                case "responsabil":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.Responsabil);
                    else
                        return query.OrderByDescending(c => c.Responsabil);

                case "client":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.Client);
                    else
                        return query.OrderByDescending(c => c.Client);

                case "nrcadastral":
                    if (sortQuery.SortingDirection == SortDirection.Asc)
                        return query.OrderBy(c => c.NrCadastral);
                    else
                        return query.OrderByDescending(c => c.NrCadastral);
           

                default: 
                    return query;
            }
        }
    }
}
