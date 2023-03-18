using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstore.Models
{
    public interface IPaymentRepository
    {
        IQueryable<Payment> Payments { get; }

        void SavePayment(Payment payment);
    }
}
