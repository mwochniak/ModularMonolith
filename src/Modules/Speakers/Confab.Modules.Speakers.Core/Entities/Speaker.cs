namespace Confab.Modules.Speakers.Core.Entities
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
    }
}