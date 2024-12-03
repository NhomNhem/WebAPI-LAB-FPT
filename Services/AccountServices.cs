using Demo19305.Models;

namespace Demo19305.Services;

// thực hiện thao tác với database
public class AccountServices : IAccountServices
{
    private AppDataContext.AppDataContext _context;
    
    public AccountServices(AppDataContext.AppDataContext context) => _context = context;

    public Task<Account> Register(string email, string password, string name)
    {
        try
        {
            var account = new Account
            {
                Email = email,
                Password = password,
                Name = name
            };
            // gọi dbset
            _context.Accounts.Add(account); // insert into
            _context.SaveChanges(); // lưu lại
            return Task.FromResult(account); // trả về account
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Account> Login(string email, string password) => throw new NotImplementedException();

    public Task<List<Account>> GetAllAccounts()
    {
        try
        {
            // lấy toàn bộ tài khoản
            // select * from Accounts
            var allAccounts = _context.Accounts.ToList();
            return Task.FromResult(allAccounts);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Account> GetAccountById(int id)
    {
        try
        {
            // lấy thông tin 1 tài khoản theo id
            // select * from Accounts where Id = id
            var account = _context.Accounts
                                .FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            return Task.FromResult(account);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Account> GetAccountByEmail(string email) {
        try
        {
            // lấy thông tin 1 tài khoản theo email
            // select * from Accounts where Email = email
            var account = _context.Accounts
                                .FirstOrDefault(x => x.Email == email);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            return Task.FromResult(account);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<List<Account>> GetAllAccountsByEmail(string email) {
        try {
         var accounts = _context.Accounts
                                .Where(x => x.Email.StartsWith(email) && x.Email != null)
                                .ToList();

            return Task.FromResult(accounts);
        }catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task<List<Account>> GetAllAccountsByName(string name) {
        try {
            var accounts = _context.Accounts
                                .Where(x => x.Name.Contains(name) && x.Name != null)
                                .ToList();

            return Task.FromResult(accounts);
        }catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task<List<Account>> GetAllAccountsByNameAndEmail(string name, string email) {
        try {
            var accounts = _context.Accounts
                                .Where(x => x.Name.Contains(name) && x.Email.StartsWith(email) && x.Name != null && x.Email != null)
                                .ToList();

            return Task.FromResult(accounts);
        }catch (Exception e) {
            throw new Exception(e.Message);
        }
    }


    public Task<Account> Register(Account account)
    {
        try
        {
            // gọi dbset
            _context.Accounts.Add(account); // insert into
            _context.SaveChanges(); // lưu lại
            return Task.FromResult(account); // trả về account
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Account> Login(Account account) => throw new NotImplementedException();

    public Task<Account> ChangePassword(int id, string password) {
        try {
            // lấy thông tin 1 tài khoản theo id
            // select * from Accounts where Id = id
            var account = _context.Accounts
                                .FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            account.Password = password;
            _context.SaveChanges();
            return Task.FromResult(account);
        }catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

}