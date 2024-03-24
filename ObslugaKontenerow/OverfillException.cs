using System;

namespace ObslugaKontenerow
{
    public class OverfillException : Exception
    {
        public OverfillException() : base("Nie udało sie załadowac towaru")
        {
            
        }
    }
}