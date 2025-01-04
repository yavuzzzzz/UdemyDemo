namespace InveonFinal.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = default!;
        public AppUser User { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public Payment Payment { get; set; } = default!;
        public int PaymentId { get; set; } = default!;

    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}
