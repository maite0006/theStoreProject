using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public Usuario() { }


        public void setPassword(string passwordSinEncriptar)
        {
            this.Password = Utilidades.Crypto.HashPasswordConBcrypt(passwordSinEncriptar, 10);
        }
        public bool ValidarPassword(string passwordIngresada)
        {
            return Utilidades.Crypto.VerifyPasswordConBcrypt(passwordIngresada, this.Password);
        }
        public bool resetearContraseña(string passwordActual, string passwordNueva)
        {
            if (ValidarPassword(passwordActual))
            {
                setPassword(passwordNueva);
                return true;
            }
            return false;
        }

        public abstract string GetRol();
       
        

    }
}