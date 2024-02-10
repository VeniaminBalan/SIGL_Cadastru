namespace SIGL_Cadastru.Utils
{
    public enum ResultState 
    {
        ExistingObject,
        NewObject
    }
    public class Result<T>
    {
        public ResultState State { get; }
        public T Value { get; }

        public Result(ResultState state, T value) 
        {
            State = state;
            Value = value;
        }
    }
}
