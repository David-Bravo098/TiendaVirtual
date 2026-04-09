using Microsoft.AspNetCore.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Tecnología", Descripcion="Productos tecnológicos"},
                new Categoria { Id = 2, Nombre = "Ropa", Descripcion="Prendas de vestir"},
                new Categoria { Id = 3, Nombre = "", Descripcion="Sin nombre definido"}
            };

            return View(categorias);
        }
    }
}