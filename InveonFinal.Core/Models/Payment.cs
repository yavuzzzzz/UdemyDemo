using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonFinal.Core.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }

    public enum PaymentType
    {
        CreditCard,
        Cash,
        BankTransfer,
        PayPal
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Cancelled,
        Failed
    }
}
