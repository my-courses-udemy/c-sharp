using Microsoft.AspNetCore.Identity;

namespace product_web_api.Models;

public class Login
{
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}