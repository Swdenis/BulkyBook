using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
        }

        public Product Product { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
