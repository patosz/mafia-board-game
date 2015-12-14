using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Model
{
    public partial class De
    {
        Random random = new Random();
        public De()
        {
            this.Valeur = "M";
        }

        public int LancerDe()
        {
            return random.Next(6) + 1;
        }

    }
}