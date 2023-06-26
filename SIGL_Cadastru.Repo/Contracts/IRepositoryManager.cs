﻿
namespace Contracts;

public interface IRepositoryManager
{
    public ICerereRepository Cerere { get; }
    public ILucrareRepository Lucrare { get;}
    public IPersoanaRepository Persoana { get; }

    Task SaveAsync();
}
