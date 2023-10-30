using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Adondevamos.Models
{
    public class Perfil
   
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public int IdActiviades { get; set; }

        // Otros campos de usuario, como dirección, fecha de nacimiento, etc.
    }

}