using Microsoft.AspNetCore.Http;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Product.Commands
{
    public class CreateProductCommand : Command
    {
        public CreateProductCommand() { }

        public CreateProductCommand(string name, float price, IFormFile imagem, Guid systemAdminId)
        {
            Name = name;
            Price = price;
            Imagem = imagem;
            SystemAdminId = systemAdminId;
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public IFormFile Imagem { get; set; }
        public Guid SystemAdminId { get; set; }
    }
}
