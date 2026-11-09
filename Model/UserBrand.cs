namespace MyPractice5.Model
{
    public class UserBrand
    {
        public int UserId { get; set; }
        public int BrandId { get; set; }


        public Users? User { get; set; }
        public Brand? Brand { get; set; }


    }
}
