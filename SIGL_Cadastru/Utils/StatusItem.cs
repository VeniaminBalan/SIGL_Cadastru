using Models;

namespace SIGL_Cadastru.Utils
{
    public enum EntityState 
    {
        Original,
        Added,
        Removed
    }
    internal class StatusItem
    {
        public EntityState State { get; set; } = EntityState.Original;
        public CerereStatus CerereStatus {get; init;}

        public StatusItem(CerereStatus cerereStatus, EntityState state = EntityState.Original)
        {
            CerereStatus = cerereStatus;
            State = state;

        }
    }
}
