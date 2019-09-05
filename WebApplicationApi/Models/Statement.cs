using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Models
{
    public class Statement
    {
        public DateTime datetransaction { get; set; }
        public decimal money { get; set; }
    }
}