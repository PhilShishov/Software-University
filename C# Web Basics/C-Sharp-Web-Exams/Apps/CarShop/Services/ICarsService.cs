using System.Collections.Generic;

using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void AddCar(AddCarInputModel input, string userId);

        IEnumerable<CarViewModel> GetAllById(string userId);

        IEnumerable<CarViewModel> GetAllWithIssues();
    }
}
