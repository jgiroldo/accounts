using Accounts.Framework.Database;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Accounts.Domain.Entities
{
    [DataContract]
    public class Person : BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "birth_date")]
        public DateTime? BirthDate { get; set; }

        [DataMember(Name = "social_name")]
        public string SocialName { get; set; }

        [DataMember(Name = "company_name")]
        public string ConpanyName { get; set; }

        public override object[] GetKey() => new object[] { Id };
    }
}
