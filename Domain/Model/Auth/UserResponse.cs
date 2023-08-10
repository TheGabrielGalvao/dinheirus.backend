using Util.Enumerator;

namespace Domain.Model.Auth
{
    public class UserResponse
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ERegisterStatus Status { get; set; }
        public Guid? ProfileUuid { get; set; }
    }
}
