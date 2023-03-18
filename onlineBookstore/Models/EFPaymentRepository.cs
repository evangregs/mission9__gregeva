using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstore.Models
{
    public class EFPaymentRepository : IPaymentRepository
    {
        private BookstoreContext context;
        public EFPaymentRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Payment> Payments => context.Payments.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePayment(Payment payment)
        {
            context.AttachRange(payment.Lines.Select(x => x.Book));

            if (payment.PaymentId == 0)
            {
                context.Payments.Add(payment);
            }

            context.SaveChanges();
        }
    }
}
