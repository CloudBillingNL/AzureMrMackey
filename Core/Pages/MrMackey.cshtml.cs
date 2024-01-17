using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureMrMackey.Core.Pages;

public class PrivacyModel : PageModel
{
    private RandomNumberGenerator rng = RandomNumberGenerator.Create();

    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    internal int HeadSize;

    public void OnGet(int size = 0)
    {
        HeadSize = size;
        _logger.LogInformation("Testing {Size}", size);

        var bytes = new byte[size];
        rng.GetBytes(bytes);
        var random = Convert.ToBase64String(bytes).Substring(0, size);
        Response.Headers["X-MrMackey"] = random;
    }
}
