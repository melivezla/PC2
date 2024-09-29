using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; 
using System.Linq; 
using Banco.Models; 

namespace Banco.Controllers
{
    public class CuentasBancariasController : Controller
    {
        
        private static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

       
        public IActionResult Index()
        {
            return View(cuentas); 
        }

        
        public IActionResult Crear()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Crear(CuentaBancaria cuenta)
        {
            if (ModelState.IsValid)
            {
                cuentas.Add(cuenta); 
                return RedirectToAction(nameof(Index)); 
            }
            return View(cuenta); 
        }


        public IActionResult Editar(int id)
        {
            
            var cuenta = cuentas.FirstOrDefault(c => c.Id == id);
            if (cuenta == null)
            {
                return NotFound(); 
            }
            return View(cuenta); 
        }

        
        [HttpPost]
        public IActionResult Editar(CuentaBancaria cuenta)
        {
            if (ModelState.IsValid)
            {
                
                var cuentaExistente = cuentas.FirstOrDefault(c => c.Id == cuenta.Id);
                if (cuentaExistente == null)
                {
                    return NotFound(); 
                }

                
                cuentaExistente.NombreTitular = cuenta.NombreTitular;
                cuentaExistente.TipoCuenta = cuenta.TipoCuenta;
                cuentaExistente.SaldoInicial = cuenta.SaldoInicial;
                cuentaExistente.Email = cuenta.Email;

                return RedirectToAction(nameof(Index));  
            }
            return View(cuenta); 
        }
    }
}
