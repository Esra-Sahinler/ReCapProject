using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //ColorTest();
            //BrandTest();
        }
        /*private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Purple" });
            //colorManager.Delete(new Color { ColorId = 2 });
            colorManager.Update(new Color { ColorId = 3, ColorName = "Rolls Royce" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

        }*/
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            /*carManager.Add(new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 40000,
                Description = "Honda",
                ModelYear = 2000
            });
            carManager.Delete(new Car
            {
                Id = 2
            });*/
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            /*foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id+" / "+car.Description);
            }
            carManager.GetById(5);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " / " + car.BrandName + " / " + car.ColorName);
            }*/
        }
        /*private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDalcs());
            
            //brandManager.Add(new Brand { BrandName = "Mercedes" });
            //brandManager.Delete(new Brand { BrandId = 2 });
            //brandManager.Update(new Brand { BrandId = 3, BrandName = "Rolls Royce" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }*/
    }
}
