using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeV2.Business.Common
{
    public class ServiceResponse
    {
        public bool IsSuccesful { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class ServiceResponse<T>
    {
        public bool IsSuccesful { get; set; }
        public string ErrorMessage { get; set; }
        public T Result  { get; set; }
    }
}
