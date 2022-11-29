using System.DirectoryServices.AccountManagement;

namespace AdManager.Services
{
    public class CreateUser
    {
        public void Create()
        {
            var context = new PrincipalContext
                (ContextType.Domain, $"networksecuritybr.local", $"dc=networksecuritybr,dc=local", ContextOptions.Negotiate);

            UserPrincipal userPrincipal = new UserPrincipal(context)
            {
                
            };
            userPrincipal.SetPassword("Mudar123"); // Senha padrão
            userPrincipal.ExpirePasswordNow();
            userPrincipal.Enabled = true; // Habilita o usuário
            userPrincipal.Save();
        }

         
    }
}