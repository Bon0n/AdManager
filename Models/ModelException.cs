namespace AdManager.Models
{
    public class ModelException : Exception
    {
        public ModelException(string error) : base(error)
        {}

        public static void When(bool isValid, string msg)
        {
            if(isValid)
                throw new ModelException(msg);
        }

    }
}