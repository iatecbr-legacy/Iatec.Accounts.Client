using System.Runtime.Serialization;

namespace Iatec.Accounts.Client.Model
{
    [DataContract]
    public class ErrorModel
    {
        [DataMember(Name = "error")]
        public bool IsError { get; set; } = true;

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }
    }
}