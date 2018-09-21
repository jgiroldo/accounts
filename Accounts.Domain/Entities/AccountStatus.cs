using Accounts.Framework.Database;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Accounts.Domain.Entities
{
    [DataContract]
    public class AccountStatus : BaseEntity
    {
        public AccountStatus() { }

        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }

        public override object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}
