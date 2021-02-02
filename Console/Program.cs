using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id);
                Console.WriteLine("Marka ID: " + car.BrandId);
                Console.WriteLine("Renk ID: " + car.ColorId);
                Console.WriteLine("Günlük Ücret: " + car.DailyPrice);
                Console.WriteLine("Model Yılı: " + car.ModelYear);
                Console.WriteLine("Açıklaması: " + car.Description);
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
