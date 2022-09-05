﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        public Car GetById(int id);
        public List<Car> GetAll();
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
    }
}
