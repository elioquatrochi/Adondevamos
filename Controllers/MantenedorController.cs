using Microsoft.AspNetCore.Mvc;

using Adondevamos.Datoss;
using Adondevamos.Models;
using System.Web.Mvc;

namespace Adondevamos.Controllers
{
    public class MantenedorController : Controller
    {


        ContactoDatos _ContactoDatos = new ContactoDatos();

        public ActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public ActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }
       
        [HttpPost]
        public ActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public ActionResult Editar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public ActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public ActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public ActionResult Eliminar(ContactoModel oContacto)
        {
  
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
