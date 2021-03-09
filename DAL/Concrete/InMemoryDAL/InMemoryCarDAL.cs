using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Concrete.InMemoryDAL
{
    public class InMemoryCarDAL : ICarDAL
    {
        List<Car> _cars;
        public InMemoryCarDAL()
        {
            _cars = new List<Car>
            {
                new Car{Id= 1,BrandId=1,ColorId=1,ModelYear=2010,DailyPrice=250000,Description="2010 Model Volvo Siyah Renkli Araba"},
                new Car{Id= 2,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=150000,Description="2020 Model Volvo Siyah Renkli Araba"},
                new Car{Id= 3,BrandId=2,ColorId=2,ModelYear=2021,DailyPrice=500000,Description="2021 Yeni süper Mercedes Mavi renkli Araba"},
                new Car{Id= 4,BrandId=2,ColorId=3,ModelYear=2009,DailyPrice=90000,Description="2009 model Mercedes Kırmızı renkli Araba"},
                new Car{Id= 5,BrandId=1,ColorId=3,ModelYear=2011,DailyPrice=60000,Description="2011 model Volvo Kırmızı renkli Araba"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDel = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDel);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public Car GetCarClassByIdDAL(int id)
        {
            return _cars.SingleOrDefault(c => c.Id ==id);
            
        }

        public void Update(Car car)
        {
            Car carToUpt = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpt.BrandId = car.BrandId;
            carToUpt.ColorId = car.ColorId;
            carToUpt.DailyPrice = car.DailyPrice;
            carToUpt.ModelYear = car.ModelYear;
            carToUpt.Description = car.Description;
        }
    }
}
