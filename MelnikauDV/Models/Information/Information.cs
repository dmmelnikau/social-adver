using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models.Information
{
    public class Information
    {
        public InfAdv InfAdv { get; set; }
        public void SomeInf(string osName)
        {
            InfAdv = InfAdv.getInstance(osName);
        }
    }
}
