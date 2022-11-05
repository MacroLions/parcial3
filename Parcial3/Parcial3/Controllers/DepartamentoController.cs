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
    public class DepartamentoController : ApiController
    {
        // GET api/values
        public Departamento Get(int id)
        {
            return DepartamentoData.Select(id);
        }
        // GET para Select(Varios elementos)
        public List<Departamento> Get()
        {
            return DepartamentoData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Departamento oBodega)
        {
            return DepartamentoData.Save(oBodega);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Departamento nDepartamento)
        {
            return DepartamentoData.Edit(nDepartamento);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return DepartamentoData.Delete(id);
        }
    }
}
