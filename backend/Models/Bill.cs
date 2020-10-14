using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models {
    public enum TypeState { primerrecordatorio = 1, segundorecordatorio = 2, desactivado = 3 }
    public class Bill {

        [BsonId]
        public ObjectId Id { get; set; }
        public double Total { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double Retention { get; set; }
        public DateTime CreateAt { get; set; }
        public TypeState State { get; set; }
        public bool IsPaid { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public DateTime PaymentDate { get; set; }
        public string Client { get; set; }
        public string Location { get; set; }
        
        
        
    }
}