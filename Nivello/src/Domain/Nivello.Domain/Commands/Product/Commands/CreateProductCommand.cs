using Microsoft.AspNetCore.Http;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Product.Commands
{
    public class CreateProductCommand : Command
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public IFormFile Imagem { get; set; }
        public Guid SystemAdminId { get; set; }
    }
}
