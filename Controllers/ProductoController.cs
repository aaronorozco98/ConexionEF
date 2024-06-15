
using ConexionEF;
using ConexionEF.Entities;
using ConexionEF.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductoController : Controller
{
    // public readonly ApplicationDbContext _context;
    public readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductoAdd()
        {
            TipoProducto entity = new TipoProducto();
            entity.Id = new Guid();
            entity.Nombre = "Refresco";
            entity.Descripcion = "Bebida sabor naranja";

            _context.TiposProductos.Add(entity);
            _context.SaveChanges();

            return View();
        }

        public IActionResult ProductoList()
        {
            List<ProductoModel> list = 
            _context.TiposProductos
            .Select(m => new ProductoModel()
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Descripcion = m.Descripcion
            }
            )
            .ToList();

            return View(list);
        }

        public IActionResult ProductoEdit(Guid Id)
        {
            // Id = new Guid("43050F98-CA21-4A3A-BFF0-08DC8B2ECE47");

            TipoProducto entity = _context.TiposProductos
            .Where(m => m.Id == Id)
            .FirstOrDefault();

            entity.Nombre = "jugo";
            entity.Descripcion = "Jumex";

            _context.TiposProductos.Update(entity);
            _context.SaveChanges();

            return View();
        }

        public IActionResult MarcaDelete()
        {
            return View();
        }
}