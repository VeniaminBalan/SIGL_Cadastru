﻿using SIGL_Cadastru.Repo.Models;

namespace Contracts;

public interface ICerereRepository
{
    Task<IEnumerable<Cerere>> GetAllAync(bool trackChanges);
    Task<Cerere> GetByIdAsync(Guid companyId, bool trackChanges);
    Task<IEnumerable<Cerere>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreateCerere(Cerere cerere);
    void DeleteCerere(Cerere cerere);
}