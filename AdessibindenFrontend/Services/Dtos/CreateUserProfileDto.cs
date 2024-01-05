

namespace AdessibindenFrontend.Services.Dtos
{
    public class CreateUserProfileDto : IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateUserProfileDto()
        {
            
        }
    }
}
