using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models.Information
{
    public class InfAdv
    {
        private static InfAdv instance;

        public string Inf { get; private set; }

        protected InfAdv(string inf)
        {
            this.Inf = inf;
        }

        public static InfAdv getInstance(string inf)
        {
            if (instance == null)
                instance = new InfAdv(inf);
            return instance;
        }
    }
}
