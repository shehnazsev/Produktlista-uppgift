using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace Resources.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddToList_ShouldReturnSuccess_WhenProductAddedToList()
        {
            var productService = new ProductService();
            var product = new Product();

            ResultStatus result = productService.AddToList(product);

            Assert.Equal(ResultStatus.Success, result);
            Assert.Single(productService.GetAllProducts());
        }
    }
}