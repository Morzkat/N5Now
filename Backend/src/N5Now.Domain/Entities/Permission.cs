namespace N5Now.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public Employee Employee { get; set; }
        public PermissionType PermissionType { get; set; } = new PermissionType();
        public DateTime Date { get; set; }
    }
}
