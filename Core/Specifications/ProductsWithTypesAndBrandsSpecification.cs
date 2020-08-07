﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            :base(x=>
            (string.IsNullOrEmpty(productParams.search)||x.Name.ToLower().Contains(productParams.search))&&
            (!productParams.BrandId.HasValue || x.ProductBrandId== productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId== productParams.TypeId)
            )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(X => X.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort)) 
            {
               switch(productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}