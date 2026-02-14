

namespace CSharpCollective.Services

{
    public class LogCheck 
    {

        public bool LoggedIn(string Id)
        {
            if (Id==null || Id=="")
            {
                return false; 
            }
            return true;
        }
    }
}
