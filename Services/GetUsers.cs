using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using AdManager.ViewModels;

namespace AdManager.Services
{
    public class GetUsers
    {
        public List<UserViewModel> Get()
        {
            var context = new PrincipalContext
                (ContextType.Domain, $"networksecuritybr.local", $"dc=networksecuritybr,dc=local", ContextOptions.Negotiate,"andrei.oliveira","Mudar@123");

            var userPrincipal = new UserPrincipal(context);

            var searcher = new PrincipalSearcher(userPrincipal);
            
            var Users = new List<UserViewModel>();
            foreach(var result in searcher.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                
                var user = new UserViewModel
                (
                    de.Properties["givenName"].Value,
                    de.Properties["samAccountName"].Value,
                    de.Properties["emailAddress"].Value
                );
                
                Users.Add(user);
            }
            return Users;
        }

        public List<UserViewModel> Get(string name, string username)
        {
            var context = new PrincipalContext
                (ContextType.Domain, $"networksecuritybr.local", $"dc=networksecuritybr,dc=local", ContextOptions.Negotiate,"andrei.oliveira","Mudar@123");

            var userPrincipal = new UserPrincipal(context);

            if(!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(username))
                userPrincipal.DisplayName = name;

            if(string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(username))
                userPrincipal.SamAccountName = username;   

            if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(username))
            {
                userPrincipal.DisplayName = name;
                userPrincipal.SamAccountName = username;   
            }

            var searcher = new PrincipalSearcher(userPrincipal);
            
            var Users = new List<UserViewModel>();
            foreach(var result in searcher.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                
                var user = new UserViewModel
                (
                    de.Properties["displayName"].Value,
                    de.Properties["samAccountName"].Value,
                    de.Properties["emailAddress"].Value
                );
                
                Users.Add(user);
            }
            return Users;
        }
    }
}