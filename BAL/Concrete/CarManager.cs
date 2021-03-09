using BAL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public void AddCar(Car car)
        {
            _carDAL.Add(car);
        }

        public void DeleteCar(Car car)
        {
            _carDAL.Delete(car);
        }

        public List<Car> GetAllCars()
        {
            return _carDAL.GetAll();
        }

        public List<Car> GetCarById(int id)
        {
            return _carDAL.GetById(id);
        }

        public Car GetCarClassById(int id)
        {
            return _carDAL.GetCarClassByIdDAL(id);

        }

        public void UpdateCar(Car car)
        {
            _carDAL.Update(car);
        }
    }
}
