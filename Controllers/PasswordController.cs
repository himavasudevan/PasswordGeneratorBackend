using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorApi.Data;
using PasswordGeneratorApi.Models;
using PasswordGeneratorApi.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PasswordController : ControllerBase
{
    private readonly PasswordService _passwordService;
    private readonly ApplicationDbContext _context;

    public PasswordController(PasswordService passwordService, ApplicationDbContext context)
    {
        _passwordService = passwordService;
        _context = context;
    }

    [HttpPost("generate")]
    public ActionResult<PasswordResponse> GeneratePassword(PasswordRequest request)
    {
        var password = _passwordService.GeneratePassword(request.Length, request.IncludeUppercase, request.IncludeLowercase, request.IncludeNumbers, request.IncludeSpecialCharacters);
        return Ok(new PasswordResponse { Password = password });
    }

    [HttpPost("store")]
    public async Task<IActionResult> StorePassword(PasswordResponse response)
    {
        var storedPassword = new StoredPassword { Password = response.Password, CreatedAt = DateTime.UtcNow };
        _context.StoredPasswords.Add(storedPassword);
        await _context.SaveChangesAsync();
        return Ok(storedPassword);
    }
}
