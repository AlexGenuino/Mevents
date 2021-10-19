namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CPF { get; set; }

        public string Phone { get; set; }
    }
}