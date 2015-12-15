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

        public void LancerDe()
        {
            int rand = random.Next(6) + 1;

            if (rand <= 3)
                this.Valeur = "M";
            else if (rand <= 5)
                this.Valeur = "P";
            else this.Valeur = "D";
        }

    }
}