using Microsoft.AspNetCore.Http;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using System;

namespace Nivello.Domain.Commands.Product.Commands
{
    public class CreateProductCommand : Command
    {
        public string Name { get; private set; }
        public float Price { get; private set; }
        public IFormFile Imagem { get; private set; }
        public Guid SystemAdminId { get; private set; }
    }
}
