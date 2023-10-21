using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL.DataAccess.Models.Custom
{
    public class AutorizacionResponse
    {
        public string Token { get; set; }
        public bool Resultado { get; set; }

        public string Mensaje { get; set; }
    }
}
