﻿using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public interface IorderMasterService
    {
        int InsertUpdateOrderMaster(OrderMaster eModel);
    }
}