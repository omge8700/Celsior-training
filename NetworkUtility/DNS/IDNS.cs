﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.DNS
{
    public  interface IDNS
    {
        bool DNS();
        object SendDNS();
    }
}