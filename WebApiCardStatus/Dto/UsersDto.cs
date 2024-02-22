using System.ComponentModel.DataAnnotations;

namespace WebApiCardStatus.Dto
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
