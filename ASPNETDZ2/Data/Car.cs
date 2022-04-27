using System;
using System.Collections.Generic;

#nullable disable

namespace ASPNETDZ2.Data
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] CarImage { get; set; }
    }
}
