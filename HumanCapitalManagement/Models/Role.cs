    namespace HumanCapitalManagement.Models
{
    public partial class Role
    {
        public Role()
        {
            Logins = new List<Login>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}
