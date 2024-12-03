using Demo19305.Models;

namespace Demo19305.Services;

// interface này sẽ chứa các phương thức
// liên quan đến bảng tài khoản
public interface IAccountServices
{
    // đăng ký, đăng nhập
    Task<Account> Register(string email, string password, string name);
    Task<Account> Login(string email, string password);
    // lấy danh sách tất cả tài khoản
    Task<List<Account>> GetAllAccounts();
    
    // lấy thông tin 1 tài khoản theo id
    Task<Account> GetAccountById(int id);

    // lay thong tin tu email được bắt đầu từ "..."
    Task<List<Account>> GetAllAccountsByEmail(string email);

    // lấy các tài khoản tên có chứa chuỗi '...'
    Task<List<Account>> GetAllAccountsByName(string name);

    //Lấy các tài khoản có tên chúa chuỗi và email bắt đầu từ '...'
    Task<List<Account>> GetAllAccountsByNameAndEmail(string name, string email);

    // register account
    Task<Account> Register(Account account);

    // login account
    Task<Account> Login(Account account);

    // change password
    Task<Account> ChangePassword(int id, string password);


}

