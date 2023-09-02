
namespace SIGL_Cadastru.Utils
{
    public class ComboItem
    {
        public Guid ID { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }
}
