using System;

namespace JeuDeRole_v1._2
{
    public class De
    {
        protected Random randomDe = new Random();

        public int LanceLeDe()
        {
            var result = randomDe.Next(1, 7);

            return result;
        }

    }
}