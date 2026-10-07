using Microsoft.AspNetCore.Mvc;

namespace RulimAuto.WebApi.Controllers;

public class RulimAutoController : Controller
{
    public async Task<IActionResult> index()
    {
        return View("index");
    }
    
}