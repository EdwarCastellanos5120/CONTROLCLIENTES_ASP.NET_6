using Microsoft.AspNetCore.Mvc;
using CRUDCLIENTES.BDCliente;
using CRUDCLIENTES.Models;

using Microsoft.AspNetCore.Authorization;

namespace CRUDCLIENTES.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        ClienteDatos _clDatos = new ClienteDatos();

        /*
         Devuelve la Vista con todos los Clientes
         */
        public IActionResult Listar()
        {
            var listaCliente = _clDatos.Listar();
            return View(listaCliente);
        }

        /*
         Devuelve la Vista para Guardar
         */
        public IActionResult Guardar()
        {
            return View();
        }

        /*
         Devuelve Vista Guardar el CLiente 
         */
        [HttpPost]
        public IActionResult Guardar(ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _clDatos.Guardar(clienteModel);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        /*
         Devuelve la Vista Editar con el Modelo
         */
        public IActionResult Editar(int idCliente)
        {
            var respuesta = _clDatos.Obtener(idCliente);
            return View(respuesta);
        }

        /*
         Devuelve Vista Editar el CLiente
         */
        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _clDatos.Editar(clienteModel);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idCLiente)
        {
            var objectContacto = _clDatos.Obtener(idCLiente);
            return View(objectContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel clienteModel)
        {

            var respuesta = _clDatos.Eliminar(clienteModel.IdCliente);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
