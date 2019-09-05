using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Models
{
    public class Communicator
    {
        public bool State { get; set; }
        public decimal Money { get; set; }
        public string Message { get; set; }
    }
}