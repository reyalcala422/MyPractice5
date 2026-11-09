namespace MyPractice5.Model
{
    public class Brand
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<UserBrand> UserBrands { get; set; } = new List<UserBrand>();
    }
}
