using Demo19305.Models;
using Demo19305.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo19305.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountServices _accountServices;

    public AccountController(IAccountServices accountServices) => _accountServices = accountServices;

    // lấy toàn bộ tài khoản
    [HttpGet]
    // http://localhost:5000/api/get-all-accounts
    [Route("/api/get-all-accounts")]
    public async Task<IActionResult> GetAllAccounts() {
        try {
            var allAccounts = await _accountServices.GetAllAccounts();
            return Ok(
                      new
                      {
                          status = true, data = allAccounts
                      }
                     );
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin tài khoản theo id
    [HttpGet]
    // http://localhost:5000/api/get-account-by-id/1
    [Route("/api/get-account-by-id/{id}")]
    public async Task<IActionResult> GetAccountById(int id) {
        try {
            var account = await _accountServices.GetAccountById(id);
            return Ok(
                      new
                      {
                          status = true, data = account
                      }
                     );
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    // lấy thông tin tài khoản theo email
    [HttpGet]
    // http://localhost:5000/api/get-account-by-email/1
    [Route("/api/get-account-by-email/{email}")]
    public async Task<IActionResult> GetAccountByEmail(string email) {
        try {
            var account = await _accountServices.GetAllAccountsByEmail(email);
            return Ok(
                      new
                      {
                          status = true, data = account
                      }
                     );
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    // lấy các tài khoản có tên chứa chuỗi '...' và email bắt đầu từ '...'
    [HttpGet]
    // http://localhost:5000/api/get-all-accounts-by-name-and-email?name=...&email=...
    [Route("/api/get-all-accounts-by-name-and-email")]
    public async Task<IActionResult> GetAllAccountsByNameAndEmail(string name, string email) {
        try {
            var accounts = await _accountServices.GetAllAccountsByNameAndEmail(name, email);
            return Ok(
                      new
                      {
                          status = true, data = accounts
                      }
                     );
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }


    // lấy các tài khoản có tên chứa chuỗi '...'
    [HttpGet]
    // http://localhost:5000/api/get-all-accounts-by-name?name=...
    [Route("/api/get-all-accounts-by-name")]
    public async Task<IActionResult> GetAllAccountsByName(string name) {
        try {
            var accounts = await _accountServices.GetAllAccountsByName(name);
            return Ok(
                      new
                      {
                          status = true, data = accounts
                      }
                     );
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }


    // đăng ký tài khoản
    [HttpPost]
    // http://localhost:5000/api/register
    [Route("/api/register")]
    public async Task<IActionResult> Register([FromBody] Account account) {
        try {

            Console.WriteLine(account.Email);
            Console.WriteLine(account.Password);
            Console.WriteLine(account.Name);

            if (string.IsNullOrEmpty(account.Email))
                return StatusCode(500, "Email is required");
            if (string.IsNullOrEmpty(account.Password))
                return StatusCode(500, "Password is required");
            if (string.IsNullOrEmpty(account.Name))
                return StatusCode(500, "Name is required");

            account = await _accountServices.Register(account.Email, account.Password, account.Name);
            return Ok(new { status = true, data = account });
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    // đăng nhập tài khoản
    [HttpPost]
    // http://localhost:5000/api/login
    [Route("/api/login")]
    public async Task<IActionResult> Login([FromBody] Account account) {
        try {
            if (string.IsNullOrEmpty(account.Email))
                return StatusCode(500, "Email is required");
            if (string.IsNullOrEmpty(account.Password))
                return StatusCode(500, "Password is required");

            account = await _accountServices.Login(account);
            return Ok(new { status = true, data = account });
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }


    // đổi mật khẩu
    [HttpPut]
    // http://localhost:5000/api/change-password/1
    [Route("/api/change-password/{id}")]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] Account account) {
        try {
            if (string.IsNullOrEmpty(account.Password))
                return StatusCode(500, "Password is required");

            account = await _accountServices.ChangePassword(id, account.Password);
            return Ok(new { status = true, data = account });
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }


}