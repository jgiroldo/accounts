using Accounts.Framework.Database;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Accounts.Domain.Entities
{

    [DataContract]
    public class Transaction : BaseEntity
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "operation_date")]
        public DateTime OperationDate { get; set; }

        [DataMember(Name = "operation_type")]
        public int OperationType { get; set; }

        [DataMember(Name = "source_account_id")]
        public int? SourceAccountId { get; set; }

        [DataMember(Name = "source_account")]
        public virtual Account SourceAccount { get; set; }

        [DataMember(Name = "destiny_account_id")]
        public int? DestinyAccountId { get; set; }

        [DataMember(Name = "destiny_account")]
        public virtual Account DestinyAccount { get; set; }

        [DataMember(Name = "value")]
        public float Value { get; set; }

        [DataMember(Name = "is_reversed")]
        public bool IsReversed { get; set; }

        public override object[] GetKey() => new object[] { Id };
    }
}

