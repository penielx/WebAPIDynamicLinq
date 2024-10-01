using Microsoft.AspNetCore.Mvc;
using WebAPIDynamicLinq.Model;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace WebAPIDynamicLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> _products;

        public ProductsController()
        {
            _products = DataSource.GetProducts();
        }

        [HttpGet]
        public IActionResult Get([FromQuery] QueryParams queryParams)
        {
            // IQueryable for dynamic querying
            IQueryable<Product> query = _products.AsQueryable();

            // Filtering
            if (!string.IsNullOrEmpty(queryParams.Filter))
            {
                query = query.Where(queryParams.Filter);
            }

            // Sorting
            if (!string.IsNullOrEmpty(queryParams.Orderby))
            {
                query = query.OrderBy(queryParams.Orderby);
            }

            // Count
            if (queryParams.Count)
            {
                return Ok(new { totalCount = query.Count() });
            }


            // Selecting specific fields
            if (!string.IsNullOrEmpty(queryParams.Select))
            {
                var selectedProperties = queryParams.Select.Split(',');
                var anonymousQuery = query.Select($"new({string.Join(",", selectedProperties)})");
                return Ok(anonymousQuery.ToDynamicList());
            }

            // Pagination
            if (queryParams.Skip.HasValue)
            {
                query = query.Skip(queryParams.Skip.Value);
            }
            if (queryParams.Top.HasValue)
            {
                query = query.Take(queryParams.Top.Value);
            }

            return Ok(query.ToList());
        }
    }
}
