using AutoMapper;
using ECommerce.Api.DTOs;
using ECommerce.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Api.Helpers {
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string> {
        private readonly IConfiguration _config;
        public ProductUrlResolver (IConfiguration config) {
            _config = config;
        }

        public string Resolve (Product source, ProductDto destination, string destMember, ResolutionContext context) {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"]+source.PictureUrl;
            }

            return null;
        }
    }
}