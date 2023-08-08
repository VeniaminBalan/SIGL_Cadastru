﻿using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Contracts
{
    public interface IPersoanaService
    {
        Task<IEnumerable<PersoanaDto>> GetAllAync(bool trackChanges);
        Task<PersoanaDto> GetByIdAsync(Guid Id, bool trackChanges);
        Task<IEnumerable<PersoanaDto>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void CreatePersoana(Persoana perosana);
        void DeletePersoana(Persoana perosana);

        Task<IEnumerable<PersoanaDto>> GetAllExecutantiAync(bool trackChanges);
        Task<IEnumerable<PersoanaDto>> GetAllResponsabiliAync(bool trackChanges);
        Task<IEnumerable<PersoanaDto>> GetAllClientiAync(bool trackChanges);
    }
}
