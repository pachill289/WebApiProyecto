using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_proyecto.DataContract
{
    public class Response : Request
    {
        public sbyte ErrorCode { get; set; } //valores desde -128 hasta 127
        public string Description { get; set; }

    }
}
