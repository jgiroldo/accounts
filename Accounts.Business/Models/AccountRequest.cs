using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Business.Models
{
    public class AccountRequest
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "creation_date")]
        public DateTime? CreationDate { get; set; }
    }
}
