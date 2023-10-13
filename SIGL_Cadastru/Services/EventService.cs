namespace SIGL_Cadastru.Services;


/// <summary>
/// global event raising
/// singleton service
/// </summary>
public class EventService 
{
    public event EventHandler CereriUpdateRequire;
    public  virtual void OnCereriUpdateRequire(EventArgs e)
    {
        CereriUpdateRequire?.Invoke(this, e);
    }


    public event EventHandler PersoaneUpdateRequire;
    public virtual void OnPersoaneUpdateRequire(EventArgs e)
    {
        PersoaneUpdateRequire?.Invoke(this, e);
    }
}
