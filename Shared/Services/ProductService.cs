using Newtonsoft.Json;
using Resources.Enums;
using Resources.Models;
using System.Text.Json.Serialization;

namespace Resources.Services
{
    public class ProductService
    {
        private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "file.json");
        private readonly FileService _fileService = new FileService(_filePath);
        private List<Product> _productList = new List<Product>();
        
        public ResultStatus AddToList(Product product)
        {
            try
            {
                if (_productList.Any(p => p.Name == product.Name))
                {
                    return ResultStatus.Exists;
                }
                _productList.Add(product);
                SaveProductsToFile();

                return ResultStatus.Success;
            }
            catch 
            {
                return ResultStatus.Failed;
            }
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                var content = _fileService.GetFromFile();
                if(!string.IsNullOrEmpty(content))
                    _productList = JsonConvert.DeserializeObject<List<Product>>(content)!;
            }
            catch {}
            return _productList;
        }

        public ResultStatus SaveProductsToFile()
        {
            var json = JsonConvert.SerializeObject(_productList);

            var result = _fileService.SaveToFile(json);
            return result;
        }

        public List<Product> GetFromFile()
        {
            var json = _fileService.GetFromFile();
            var list = new List<Product>();

            if (!string.IsNullOrEmpty(json))
            {
                list = JsonConvert.DeserializeObject<List<Product>>(json);
           
                foreach (var product in list)
                {
                    AddToList(product);
                }
            }

            return list ?? [];
        }
    }
}
