namespace Domain.Entities
{
    public class DefaultEntity 
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; } = Guid.NewGuid();

    }
}
