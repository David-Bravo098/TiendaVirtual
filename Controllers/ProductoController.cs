
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualDavid.Data;
using TiendaVirtualDavid.Models;


namespace TiendaVirtualDavid.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context;

        public ProductoController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .ToList();

            return View(productos);
        }

        //FORMULARIO
        public IActionResult Create()
        {
            return View();
        }

        //GUARDAR PRODUCTO
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //FOMULARIO DE EDICION
        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            ViewBag.Categorias = _context.Categorias.ToList();

            return View(producto);
        }
        //Actualizar Producto
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Eliminar Producto
        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}