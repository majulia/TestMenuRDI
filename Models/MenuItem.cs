using TestMenu.Models.Enum;

namespace TestMenu.Models
{
    public abstract class MenuItem
    {   

        public int Id { get; set; }
        public string Name { get; set; }
        public EType Type { get; set; }
    }
}
