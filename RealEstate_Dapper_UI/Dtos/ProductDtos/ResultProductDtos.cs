﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductDtos
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string CategoryName { get; set; }
    }
}
