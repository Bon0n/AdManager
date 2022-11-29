namespace AdManager.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get;  private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Company { get; private set; }
        public string Mirror { get; private set; }

        public User(string fullName, string userName, string email, string company, string mirror)
        {
            Validate(fullName, userName, email, company, mirror);    
        }

        private void Validate(string fullName, string userName, string email, string company, string mirror)
        {
            ModelException.When(string.IsNullOrEmpty(fullName),
                "O nome completo não pode ser vazio ou nulo.");

            ModelException.When(fullName.Length > 200,
                "O nome completo não pode conter mais que 200 caracteres.");
                
            ModelException.When(string.IsNullOrEmpty(userName),
                "O usuário não pode ser vazio ou nulo.");

            ModelException.When(userName.Length > 30,
                "O usuário não pode conter mais que 30 caracteres.");

            ModelException.When(string.IsNullOrEmpty(email),
                "O email não pode ser vazio ou nulo.");

            ModelException.When(email.Length > 55,
                "O email não pode conter mais que 55 caracteres.");

            ModelException.When(string.IsNullOrEmpty(company),
                "O email não pode ser vazio ou nulo.");

            ModelException.When(company.Length > 20,
                "O email não pode conter mais que 20 caracteres.");

            ModelException.When(string.IsNullOrEmpty(mirror),
                "O usuário espelho não pode ser vazio ou nulo.");

            ModelException.When(mirror.Length > 30,
                "O usuário espelho não pode conter mais que 30 caracteres.");

            FullName = fullName;
            Username = userName;
            Email = email;
            Company = company;
            Mirror = mirror;
            
        }
    }
}