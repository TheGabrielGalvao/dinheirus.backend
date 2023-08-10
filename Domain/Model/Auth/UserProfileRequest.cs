using Util.Enumerator;

namespace Domain.Model.Auth
{
    public class UserProfileRequest
    {
        public Guid? Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ERegisterStatus Status { get; set; }

        public ICollection<Guid>? Permissions { get; set; }
    }
}
