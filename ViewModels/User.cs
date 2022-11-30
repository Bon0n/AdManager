using AdManager.Models;

namespace AdManager.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; private set; }
        public object FullName { get;  private set; }
        public object Username { get; private set; }
        public object Email { get; private set; }

        public UserViewModel(object fullName, object username, object email)
        {
            FullName = fullName;
            Username = username;
            Email = email;
        }
    }
}