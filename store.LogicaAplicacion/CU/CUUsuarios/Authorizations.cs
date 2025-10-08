using Microsoft.IdentityModel.Tokens;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using store.LogicaNegocio.Entidades;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class Authorizations : IAuthorizations
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios; 
        
        public Authorizations(IRepositorioUsuarios repositorioUsuarios,ICrypto crypto)          {
            _repositorioUsuarios = repositorioUsuarios;
    
        }

          public Task<string> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistrarAsync(string nombre, string email, string password, string pais, string telefono)
        {
            if (await _repositorioUsuarios.FindByEmail(email) != null)
            {
                throw new ExistingUser(email);
            }
            var user= new Cliente(nombre, email, password, pais, telefono);



        }
    }
}
