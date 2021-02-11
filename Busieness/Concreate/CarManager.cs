﻿using Bussienes.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bussienes.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba bilgileri başrıyla eklenmiştir.");
            }
            else
            {
                Console.WriteLine("Lütfen fiyat bilgisini 0'dan büyük giriniz");
            }
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                Console.WriteLine("Araba bilgileri silinmiştir.");
            }
            catch (Exception)
            {
                Console.WriteLine("Belitilen Id değerinde araba kaydı bulunmamaktadır.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(c=> c.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(c=>c.ColorId == Id);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba bilgilieri güncellendi.");
            }
            else
            {
                Console.WriteLine("Lütfen 0 dan büyük bir günlük ücret değeri giriniz");
            }
        }
    }
}
