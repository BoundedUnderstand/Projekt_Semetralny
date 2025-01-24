using Microsoft.AspNetCore.Mvc;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return Content("Testowy kontroler działa!");
    }
}