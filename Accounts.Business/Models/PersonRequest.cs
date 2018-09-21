using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Business.Models
{
    public class PersonRequest
    {
        [FromQuery(Name = "cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [FromQuery(Name = "social_name")]
        public string SocialName { get; set; }

        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "company_name")]
        public string ConpanyName { get; set; }
    }
}
