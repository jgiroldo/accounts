using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Business.Models
{
    public class TransactionRequest
    {
        [FromQuery(Name = "operation_type")]
        public int OperationType { get; set; }
    }
}
