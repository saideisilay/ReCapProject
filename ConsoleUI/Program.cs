using BAL.Concrete;
using DAL.Abstract;
using DAL.Concrete.InMemoryDAL;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ARABA UYGULAMASINA HOŞ GELDİNİZ. YAPMAK İSTEDİĞİNİZ İŞLEMİ SEÇİN:\n1-TÜM LİSTEYİ GETİR\n2-ID NUMARASINA GÖRE ÜRÜNÜ GETİR.\n3-ÜRÜN EKLE\n4-ÜRÜN GÜNCELLE\n5-ÜRÜN SİL:");
            int secenek = Convert.ToInt32(Console.ReadLine());
            CarManager carManager = new CarManager(new InMemoryCarDAL());
            switch (secenek)
            {
                case 1:
                    GetAllFunc(carManager);
                    break;
                case 2:
                    GetByIdFunc(carManager);
                    break;
                case 3:
                    AddCarFunc(carManager);
                    break;
                case 4:
                    UpdateCarFunc(carManager);
                    break;
                case 5:
                    DeleteCarFunc(carManager);
                    break;
                default:
                    Console.WriteLine("Seçiminizi yapmadınız Kapatıyorum Uygulamayı.");
                    Console.ReadKey();
                    break;
            }
        }

        private static void DeleteCarFunc(CarManager carManager)
        {
            Console.WriteLine("********ÜRÜNLER*******");
            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine("{0} nolu {1} model arabanın fiyatı: {2} TL dir.", car.Id, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("********DELETE SİMÜLASYONU*******");
            Console.WriteLine("Lütfen silmek istediğiniz Araba ID'sini giriniz:");
            var delId = Convert.ToInt32(Console.ReadLine());
            //BUNUN İÇİN CLASS DÖNDÜREN Bİ FUNC YAPTIM
            Car delCar = carManager.GetCarClassById(delId);
            carManager.DeleteCar(delCar);
            Console.WriteLine("...................................\n");
            Console.WriteLine("VERİ SİLİNDİĞİNE DAİR LİSTEYİ GETİR.");
            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine("{0} nolu {1} model arabanın fiyatı: {2} TL dir.", car.Id, car.ModelYear, car.DailyPrice);
            }
        }

        private static void UpdateCarFunc(CarManager carManager)
        {
            Console.WriteLine("********ÜRÜNLER*******");
            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine("{0} nolu {1} model arabanın fiyatı: {2} TL dir.", car.Id, car.ModelYear, car.DailyPrice);
            }

            Console.WriteLine("********UPDATE SİMÜLASYONU*******");
            Console.WriteLine("Lütfen güncellemek istediğiniz Araba ID'sini giriniz:");
            var uptId = Convert.ToInt32(Console.ReadLine());
            Car UptCar = carManager.GetCarClassById(uptId);

            Console.WriteLine("BRAND ID GÜNCELLEYİN:");
            UptCar.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("COLOR ID İÇİN:\n1-SİYAH\n2-MAVİ\n3-KIRMIZI SEÇİNİZ:");
            UptCar.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ARABA MODEL YILI GİRİNİZ:");
            UptCar.ModelYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("FİYATINI GİRİN:");
            UptCar.DailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("AÇIKLAMA DEĞİŞİKLİĞİ YAPIN");
            UptCar.Description = Console.ReadLine();
            carManager.UpdateCar(UptCar);
            Console.WriteLine("VERİ GÜNCELLENDİĞİNE DAİR VERİYİ GETİR.");
            GetByIdFunc(carManager);
        }

        private static void AddCarFunc(CarManager carManager)
        {
            Console.WriteLine("********ADD SİMÜLASYONU*******OTOMATİK EKLEDİM ÜŞENDİM");
            Car car1 = new Car { Id = 6, BrandId = 3, ColorId = 3, ModelYear = 2014, DailyPrice = 150200, Description = "2014 model Bmw kırmızı renkli araba" };
            carManager.AddCar(car1);

            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine("{0} adlı arabanın fiyatı: {1} TL dir ve açıklamasını aşağıda bulabilirsiniz:\n{2}", car.Id, car.DailyPrice, car.Description);
            }
            Console.WriteLine("...................................\n");
        }

        private static void GetByIdFunc(CarManager carManager)
        {
            Console.WriteLine("********GET BYID SİMÜLASYONU için*******\n 1-5 arası id isteyin\nLütfen araba ID giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            //MANAGER FONKSİYONLARI EKLE
            List<Car> carWithId = carManager.GetCarById(id);
            foreach (var car in carWithId)
            {
                Console.WriteLine("{0} nolu Id'de bulunan araba {1}TL'dir ve \nAçıklaması:{2}'dır.", car.Id, car.DailyPrice,car.Description);
            }
            Console.WriteLine("...................................\n");
        }

        private static void GetAllFunc(CarManager carManager)
        {
            Console.WriteLine("********GET ALL SİMÜLASYONU*******");

            foreach (var car in carManager.GetAllCars())
            {
                Console.WriteLine("{0} adlı arabanın fiyatı: {1} TL dir ve açıklamasını aşağıda bulabilirsiniz:\n{2}", car.Id, car.DailyPrice, car.Description);
            }
            Console.WriteLine("...................................\n");

        }
    }
}
