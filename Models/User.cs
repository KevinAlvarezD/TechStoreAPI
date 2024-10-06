using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Models;


[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column ("username")]
    public  string Username { get; set; }

    [Column ("email")]
    public string Email { get; set; }

    [Column ("password")]
    public  string Password { get; set; }

    [Column ("role")]
    public string Role { get; set; }

    public User()
    {
    }

}
