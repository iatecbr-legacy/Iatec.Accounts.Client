using System.Runtime.Serialization;
using System.Text;

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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserModel {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Items: ").Append(Items.GetType()).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}