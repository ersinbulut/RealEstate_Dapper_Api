namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public interface IStatisticsRepository
    {
        int CategoryCount();
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        int ProductCount();
        int ApartmenCount();
        string EmployeeNameByMaxProductCount();
        decimal AverageProductPriceByRent();
        decimal AverageProductPriceBySale();
        string CityNameByMaxProductCount();
        string CategoryNameByMaxProductCount();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();
        int ActiveEmployeeCount();
        int AverageRoomCount();

    }
}
