using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface ICarDAL
    {
        List<Car> GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetCarClassByIdDAL(int id);

    }
}
