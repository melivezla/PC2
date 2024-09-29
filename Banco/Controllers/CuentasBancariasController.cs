using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using System.Linq; 
using Banco.Models; 

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

        // Acción para mostrar el formulario de edición
        public IActionResult Editar(int id)
        {
            var cuenta = cuentas.FirstOrDefault(c => c.Id == id); // Busca la cuenta por ID
            if (cuenta == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra la cuenta
            }
            return View(cuenta); // Retorna la vista de edición con la cuenta
        }

        // Acción para manejar el envío del formulario de edición
        [HttpPost]
        public IActionResult Editar(CuentaBancaria cuenta)
        {
            if (ModelState.IsValid)
            {
                var cuentaExistente = cuentas.FirstOrDefault(c => c.Id == cuenta.Id); // Busca la cuenta existente
                if (cuentaExistente == null)
                {
                    return NotFound(); // Retorna 404 si no se encuentra la cuenta
                }

                // Actualiza los valores de la cuenta existente
                cuentaExistente.NombreTitular = cuenta.NombreTitular;
                cuentaExistente.TipoCuenta = cuenta.TipoCuenta;
                cuentaExistente.SaldoInicial = cuenta.SaldoInicial;
                cuentaExistente.Email = cuenta.Email;

                return RedirectToAction(nameof(Index)); // Redirige a la lista de cuentas
            }
            return View(cuenta); // Vuelve a mostrar el formulario en caso de error
        }

        // Acción para mostrar el formulario de eliminación
        public IActionResult ConfirmarEliminar(int id) // Cambia el nombre para evitar conflictos
        {
            var cuenta = cuentas.FirstOrDefault(c => c.Id == id); // Busca la cuenta por ID
            if (cuenta == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra la cuenta
            }
            return View(cuenta); // Retorna la vista de eliminación con la cuenta
        }

        // Acción para manejar la eliminación de cuentas
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var cuenta = cuentas.FirstOrDefault(c => c.Id == id); // Busca la cuenta por ID
            if (cuenta != null)
            {
                cuentas.Remove(cuenta); // Elimina la cuenta de la lista
            }
            return RedirectToAction(nameof(Index)); // Redirige a la lista de cuentas
        }
    }
}
