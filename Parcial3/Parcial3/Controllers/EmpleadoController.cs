using Parcial3.Data;
using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial3.Controllers
{
    public class EmpleadoController : ApiController
    {
        // GET api/values
        public Empleado Get(int id)
        {
            return EmpleadoData.Select(id);
        }
        // GET para Select(Varios elementos)
        public List<Empleado> Get()
        {
            return EmpleadoData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Empleado oBodega)
        {
            return EmpleadoData.Save(oBodega);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Empleado nEmpleado)
        {
            return EmpleadoData.Edit(nEmpleado);
        }

        public bool Put(int id,bool activo,String razon)
        {
            if (activo) { return EmpleadoData.ActivarEmpleado(id,razon); }else{ return EmpleadoData.DesactivarEmpleado(id,razon); };
            
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return EmpleadoData.Delete(id);
        }
    }
}
