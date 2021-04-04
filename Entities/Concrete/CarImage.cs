using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int ImageId { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
