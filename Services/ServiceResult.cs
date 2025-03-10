﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }

        public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;

        public bool IsFail => !IsSuccess;
    }
}
