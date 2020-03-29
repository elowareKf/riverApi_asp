namespace DefaultAspNetCoreTemplate.Authentication {
    public interface ILogonService {
        JwtUser Authenticate(string username, string password, string deviceToken = null);
    }
}