using System;

namespace backend.Models.ModelView {
    public class BillView {

        public string Id { get; set; }
        public string Location { get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }

        public double Retention { get; set; }
        public DateTime CreateAt { get; set; }
        public string State { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }

        public string NameClient { get; set; }
        public string Nit { get; set; }

    }
}