using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeV2.Infrastructure.Data
{
    public partial class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
