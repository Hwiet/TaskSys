using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Lib.Exceptions;
using TaskAPI.Lib.Exceptions;

namespace TaskApi.Lib.Services
{
    public class CustomExceptionService
    {
        public void ThrowItemNotFoundException(string message = null)
        {
            throw new ItemNotFoundException(message);
        }

        public void ThrowDuplicateItemException(string message = null)
        {
            throw new DuplicateItemException(message);
        }
    }
}