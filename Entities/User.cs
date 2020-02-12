using Dapper.Contrib.Extensions;

namespace KmdProject.Entities
{
    /// <summary>
    /// Should be located in another project dedicated for entities.
    /// </summary>
    [Table("[User]")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
    }
}
