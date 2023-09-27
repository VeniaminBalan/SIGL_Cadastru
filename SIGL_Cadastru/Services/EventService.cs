namespace SIGL_Cadastru.Services;


//global event raising
public class EventService // singleton
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
