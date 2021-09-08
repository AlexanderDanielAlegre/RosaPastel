using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Infraestructure.Entities
{
    public class MateriaPrima
    {
        public int materiaPrimaId { get; set; }
        public Guid materiaPrimaKey { get; set; }
        public string Name { get; set; }
    }
}
