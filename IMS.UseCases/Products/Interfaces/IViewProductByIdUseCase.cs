using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product?> ExecuteAsync(int productId);
    }
}