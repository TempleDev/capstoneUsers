using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempleUser
{
    public abstract class TempleUser
    {
        protected string firstName { get; set; }
        protected string lastName { get; set; }
        protected string accessNet { get; set; }
        protected string email { get; set; }
    }
}