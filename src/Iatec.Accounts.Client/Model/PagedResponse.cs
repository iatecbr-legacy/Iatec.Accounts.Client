using System.Runtime.Serialization;

namespace Iatec.Accounts.Client.Model
{
    [DataContract]
    public class PagedResponse<T>
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "start")]
        public string Start { get; set; }

        [DataMember(Name = "total")]
        public string Total { get; set; }

        [DataMember(Name = "items")]
        public T[] Items { get; set; }
    }
}