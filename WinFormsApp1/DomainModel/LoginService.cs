namespace WinFormsApp1.DomainModel;

public class LoginService : ILoginService
{
    public bool Login(User user)
    {
        if (user.Name == "Vanya" && user.Password == "1239")
        {
            return true;
        }

        return false;
    }
}