using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Abstract
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<Car> GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        Car GetCarClassById(int id);
    }
}
