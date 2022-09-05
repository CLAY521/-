﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class ApiJsonResp<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        public int Status { get; set; }
        public bool Success => Status == 0;
    }
}
