using TestMenu.Models.Enum;

namespace TestMenu.Models
{
    public class Product
    {
        public int Prd_Id { get; set; }
        public string Prd_Name { get; set; }
        public EType Prd_Type { get; set; }
    }
}
