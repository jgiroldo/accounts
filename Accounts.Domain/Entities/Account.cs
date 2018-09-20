

using Accounts.Framework.Database;
using System;
using System.Runtime.Serialization;

namespace Accounts.Domain.Entities
{
    [DataContract]
    public class Account : BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "creation_date")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "parent_account")]
        public int?  ParentAccount { get; set; }

        [DataMember(Name = "master_account")]
        public int?  MasterAccount { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "person_id")]
        public int PersonId { get; set; }

        [DataMember(Name = "person")]
        public virtual Person Person { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        public override object[] GetKey() => new object[] { Id };
    }
}


