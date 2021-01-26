﻿using AdminApi.AutoGeneratedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models.Repository
{
    public interface IBillPayRepository : IDataRepository<BillPay, int>
    {
        public Task BlockBillPayAsync(int billPayID);
        public Task UnblockBillPayAsync(int billPayID);
    }
}
