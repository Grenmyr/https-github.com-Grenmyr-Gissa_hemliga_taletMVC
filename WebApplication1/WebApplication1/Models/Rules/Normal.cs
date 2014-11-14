using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Irules
{
    public class Normal : IRules
    {
        public int MaxNumberOfGuesses() { return 7; }
    }
}