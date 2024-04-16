namespace IPCalculator
{
    class SubnetMask
    {
        private uint maschera;

        public SubnetMask(string dottedDecimalMaschera)
        {
            if (!SetMaschera(dottedDecimalMaschera))
                throw new Exception("Maschera di sottorete non valida");
        }
        bool SetMaschera(string dottedDecimalMaschera)
        {
            try
            {
                uint bin = 0;
                uint[] dec = new uint[4];

                for (int i = 0; i < 4; i++)
                {
                    byte tmp = Convert.ToByte(dottedDecimalMaschera.Split(".")[i]);

                    if (tmp >= 0 && tmp <= 255)
                        dec[i] = tmp;
                }

                for (int i = 0; i < 4; i++)
                {
                    int pos = 24 - (8 * i);
                    uint tmp = dec[i] << pos;
                    bin |= tmp;
                }

                /*bool ultimoBit = true;
                uint mask = 0b10000000000000000000000000000000;
                for (int i = 0; i < 32; i++)
                {
                      if((bin&mask) == 0)
                            ultimoBit = false;

                      else
                      {
                            if(!ultimoBit)
                                  return false;
                      }

                      mask >>= 1;
                }*/

                uint a1 = ~bin;
                uint a2 = a1 + 1;

                if ((a1 & a2) != 0)
                    return false;

                maschera = bin;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public uint GetMaschera()
        {
            return maschera;
        }
    }
}
