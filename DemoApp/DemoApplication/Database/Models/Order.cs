using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Order : BaseEntity<int>, IAuditable
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public List<OrderProduct>? OrderProducts { get; set; }
        public int  Status { get; set; }

        public int SumTotalPrice { get; set; }  


    }
}
