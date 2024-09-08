namespace N5Now.Domain.Entities
{
    public class Permission: BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public PermissionType PermissionType { get; set; } = new PermissionType();
        public DateTime Date { get; set; }
    }
}
