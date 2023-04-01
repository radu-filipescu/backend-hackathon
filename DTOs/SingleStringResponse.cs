using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class SingleStringResponse
    {
        public string Value { get; set; }

        public SingleStringResponse()
        {

        }

        public SingleStringResponse(string value)
        {
            Value = value;
        }
    }
}
