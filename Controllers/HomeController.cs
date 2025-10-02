using Clique_Simples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clique_Simples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Variável estática para armazenar a contagem de cliques
        private static int _contadorDeCliques = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Index
        public IActionResult Index()
        {
            // Cria o modelo com o valor atual do contador
            var model = new ContadorModel
            {
                Cliques = _contadorDeCliques
            };

            return View(model);
        }

        // POST: Contar
        [HttpPost]
        public IActionResult Contar()
        {
            // Incrementa a variável estática
            _contadorDeCliques++;

            // Redireciona para o Index para mostrar o novo valor
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
