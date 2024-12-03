using System.ComponentModel.DataAnnotations;

namespace Demo19305.Models;

// class này sẽ map với bảng Accounts trong database
public class Account
{
    [Key] // khai báo Id là primary key
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public DateTime? Created_At { get; set; }
    public DateTime? Updated_At { get; set; }


}