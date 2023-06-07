using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NetCore_Project.DTO.DataDTO;
using NetCore_Project.DTO.FilterDTO;
using NetCore_Project.Models;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Text.Json.Nodes;

namespace NetCore_Project.Services
{
    public interface IProductService
    {
        Task<int> Count(ProductFilterDto filter);
        Product Get(long id);
        List<Product> List(ProductFilterDto filter);
        Task<(Product, Dictionary<string, string>)> Create(Product dto);
        Task<(Product, Dictionary<string, string>)> Update(long id, Product dto);
        Task<string> Delete(long id);
    }
}
