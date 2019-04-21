using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.Exceptions
{
    public class EmptyFileException : Exception
    {
        public EmptyFileException(string message) : base(message)
        {
        }
    }
}