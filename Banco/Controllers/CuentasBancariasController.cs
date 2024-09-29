using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Para usar List
using System.Linq; // Para usar LINQ
using Banco.Models; // Asegúrate de importar tu modelo

namespace Banco.Controllers
{
    public class CuentasBancariasController : Controller
    {
        // Esta lista será una simulación de la base de datos
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

        // Acción para listar cuentas bancarias
        public IActionResult Index()
        {
            return View(cuentas); // Pasa la lista de cuentas a la vista
        }

        // Acción para mostrar el formulario de creación de cuentas
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para manejar el envío del formulario de creación de cuentas
        [HttpPost]
        public IActionResult Crear(CuentaBancaria cuenta)
        {
            if (ModelState.IsValid)
            {
                cuentas.Add(cuenta); // Agrega la cuenta a la lista
                return RedirectToAction(nameof(Index)); // Redirige a la lista de cuentas
            }
            return View(cuenta); // Vuelve a mostrar el formulario en caso de error
        }
    }
}
