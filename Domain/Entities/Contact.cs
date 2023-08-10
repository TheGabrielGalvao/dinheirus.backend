using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Enumerator;

namespace Domain.Entities
{
    [Table("Contact")]
    public class Contact : DefaultEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? SecondaryPhone { get; set; }
        public EDocumentType? DocumentType { get; set; }
        public string? CpfCnpj { get; set; }
        public ERegisterStatus Status { get; set; }

    }
}
