using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08_i32vv1.Abstractions;

namespace week08_i32vv1
{
   public class BallFactory : IToyFactory
    {
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
