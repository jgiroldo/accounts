using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Accounts.Domain.Entities
{
    [DataContract]
    public class TransferViewModel
    {
        [DataMember(Name = "source_id")]
        public int SourceId { get; set; }
        [DataMember(Name = "destiny_id")]
        public int DestinyId { get; set; }
        [DataMember(Name = "value")]
        public float Value { get; set; }

    }
}
