
using Microsoft.AspNetCore.Mvc;

using TiendaVirtual.Data;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TiendaContext _context;

        public UsuarioController(TiendaContext context)
        {
            _context = context;
        }

        //LISTA USUARIOS
        public IActionResult Index()
        {
            var Usuario = _context.Usuarios
                .ToList();

            return View(Usuario);
        }

        //CREAR USUARIOS
        public IActionResult Create()
        {
            return View();
        }

        //GUARDAR USUARIOS
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //EDITAR
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            return View(usuario);
        }

        //ACTUALIZAR
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //ELIMINAR
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
