namespace Shared.Dtos
{
    public partial class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int RolId { get; set; }

        public virtual RolDto Rol { get; set; } = null!;
        public string? Password { get; set; }
    }
}