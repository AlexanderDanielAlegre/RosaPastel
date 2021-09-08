using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Bussines.Common
{
    public class ServiceResponse<T>
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccesful { get; set; }

        public T Result { get; set; }
    }

    public class ServiceResponse
    {
        public string ErrorMessage { get; set; }
        public bool IsSuccesful { get; set; }
    }

}
