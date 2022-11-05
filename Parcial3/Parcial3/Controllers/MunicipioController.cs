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
    public class MunicipioController : ApiController
    {
        // GET api/values
        public Municipio Get(int id)
        {
            return MunicipioData.Select(id);
        }
        // GET para Select(Varios elementos)
        public List<Municipio> Get()
        {
            return MunicipioData.SelectAll();
        }

        // Get por departamento
        public List<Municipio> Get(string nombreDepartamento)
        {
            return MunicipioData.SelectByDepartamento(nombreDepartamento);
        }

        // POST para Save
        public bool Post([FromBody]Municipio oBodega)
        {
            return MunicipioData.Save(oBodega);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Municipio nMunicipio)
        {
            return MunicipioData.Edit(nMunicipio);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return MunicipioData.Delete(id);
        }
    }
}
