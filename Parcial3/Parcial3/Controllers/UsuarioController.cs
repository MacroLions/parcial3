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
    public class UsuarioController : ApiController
    {
        // GET api/values
        public Usuario Get(int id)
        {
            return UsuarioData.Select(id);
        }
        // GET para Select(Varios elementos)
        public List<Usuario> Get()
        {
            return UsuarioData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Usuario oBodega)
        {
            return UsuarioData.Save(oBodega);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Usuario nUsuario)
        {
            return UsuarioData.Edit(nUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return UsuarioData.Delete(id);
        }
    }
}
