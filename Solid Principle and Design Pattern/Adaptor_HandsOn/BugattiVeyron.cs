﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_HandsOn
{
    public class BugattiVeyron : Movable
    {
        public double getSpeed()
        {
            return 268;
        }
        public double getPrice()
        {
            return 200;
        }
    }
}
