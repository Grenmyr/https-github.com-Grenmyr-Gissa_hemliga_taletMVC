using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Irules
{
    public class Hard : IRules
    {
        public int MaxNumberOfGuesses() { return 6; }
    }
}