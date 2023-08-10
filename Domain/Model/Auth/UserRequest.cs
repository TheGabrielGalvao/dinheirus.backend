using Util.Enumerator;

namespace Domain.Model.Auth
{
    public class UserRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public ERegisterStatus? Status { get; set; }
        public Guid? ProfileUuid{ get; set; }
        
    }
}
