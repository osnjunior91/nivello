using Nivello.Lib.Nivello.Lib.Domain.Data.Models;
using System;

namespace Nivello.Infrastructure.Data.Model
{
    public class Product : Entity
    {
        public Product() { }
        public string Name { get; private set; }
        public float Price { get; private set; }
        public byte[] Imagem { get; private set; }
        public Guid SystemAdminId { get; private set; }
        public SystemAdmin SystemAdmin { get; private set; }
        public Product(string name, float price, byte[] imagem, 
            Guid systemAdminId, SystemAdmin systemAdmin)
        {
            Name = name;
            Price = price;
            Imagem = imagem;
            SystemAdminId = systemAdminId;
            SystemAdmin = systemAdmin;
        }
    }
}
