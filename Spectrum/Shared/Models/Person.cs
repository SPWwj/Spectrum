namespace Spectrum.Shared.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public PersonRole Role { get; set; }
        public bool Updated { get; set; } = false;

        private static int count;

        public Person (string name, PersonRole role) { 
            Name = name;
            Role = role;
            Id = count++;
            Updated = role.Equals(PersonRole.Admin);
        }
    }

  

    public enum PersonRole
    {
        Admin,
        Adventurer
    }
}
