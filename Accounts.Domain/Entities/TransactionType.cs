using Accounts.Framework.Database;
using System.Runtime.Serialization;

namespace Accounts.Domain.Entities
{

    [DataContract]
    public class TransactionType : BaseEntity
    {
        public TransactionType() { }

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
