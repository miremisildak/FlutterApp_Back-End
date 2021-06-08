using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Market:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
