﻿using App.Repositories;
using App.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Products
{
    //Service'lerimizi mümkün olduğunca generic yapmayalım
    public class ProductService(IGenericRepository<Product> productRepository) : IProductService
    {

    }
}