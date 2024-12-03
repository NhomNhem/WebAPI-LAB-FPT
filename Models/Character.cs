using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo19305.Models;
// class này sẽ map với bảng Characters trong database
public class Character
{
    [Key]
    public int id { get; set; }

    [ForeignKey("Account")]
    public int account_id { get; set; }

    public string name { get; set; }

    public int level { get; set; }

    public int exp { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public int Coin { get; set; }

    public int HP { get; set; }

    public int MP { get; set; }

    public int atk { get; set; }

    public int def { get; set; }


}