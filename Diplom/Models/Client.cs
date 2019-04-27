using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Client
    {
        public int Client_id        { get; set; }
        public string Family        { get; set; }
        public string Name          { get; set; }
        public string Patronymic    { get; set; }
        public int Gender        { get; set; }
        public DateTime Birthday      { get; set; }
        public string Email         { get; set; }
        public string Phone         { get; set; }
        public int Consent       { get; set; }
    }
}
