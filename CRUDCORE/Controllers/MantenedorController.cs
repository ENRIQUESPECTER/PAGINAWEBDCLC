using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {//LA VISTA MOSTRARA UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {//DEVUELVE UNA VISTA

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {//RECIBE EL OBJETO PARA GUARDAR EN BD
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoDatos.Guardar(oContacto); 
            if(respuesta)
            
                return RedirectToAction("Listar");
            else
            {
                return View();
            }
            
        }
        public IActionResult Editar(int IdContacto)
        {///DEVUELVE UNA VISTA
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {///DEVUELVE UNA VISTA CON DATOS CARGADOS
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)

                return RedirectToAction("Listar");
            else
            {
                return View();
            }
        }
        public IActionResult Eliminar(int IdContacto)
        {///DEVUELVE UNA VISTA
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto) { 
        //Hace el cambio
        
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)

                return RedirectToAction("Listar");
            else
            {
                return View();
            }
        }


    }
}
