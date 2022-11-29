using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Authentication;

namespace AdManager.Services
{
    public class GetUsers
    {
        public void Get()
        {
            var context = new PrincipalContext
                (ContextType.Domain, $"networksecuritybr.local", $"dc=networksecuritybr,dc=local", ContextOptions.Negotiate);

            var searcher = new PrincipalSearcher(new UserPrincipal(context));
            
            foreach(var result in searcher.FindAll())
            {
                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                System.Console.WriteLine($"First Name: {de.Properties["givenName"].Value}");

            }

        }
    }
}