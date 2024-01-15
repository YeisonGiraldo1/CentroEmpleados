using Microsoft.AspNetCore.Mvc;
using CentroEmpleados.Datos;
using CentroEmpleados.Models;

namespace CentroEmpleados.Controllers
{
    public class MantenedorController : Controller
    {
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARA UNA LISTA DE EMPLEADOS
            var oLista = _EmpleadoDatos.Listar();
            return View(oLista);
        }


        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA 
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(EmpleadoModel eEmpleado)
        {
            //METODO RECIBE EL OBJETO PARA GUARDAR EN BD

            if(!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Guardar(eEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                 return View();
        }

         
        public IActionResult Editar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA 
            var oempleado = _EmpleadoDatos.Obtener(Id);
            return View(oempleado);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadoModel eEmpleado )
        {
            //METODO RECIBE EL OBJETO PARA GUARDAR EN BD

            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Editar(eEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }




        public IActionResult Eliminar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA 
            var oempleado = _EmpleadoDatos.Obtener(Id);
            return View(oempleado);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoModel eEmpleado)
        {
            //METODO RECIBE EL OBJETO PARA GUARDAR EN BD


            var respuesta = _EmpleadoDatos.Eliminar(eEmpleado.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }






    }

}

