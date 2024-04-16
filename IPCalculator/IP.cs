namespace IPCalculator
{
    class IP
    {
        uint indirizzo;

        public IP(string dottedDecimalIndirizzo)
        {
            if (!SetIndirizzo(dottedDecimalIndirizzo))
                throw new Exception("Indirizzo IP non valido");
        }

        bool SetIndirizzo(string dottedDecimalIndirizzo)
        {
            try
            {
                uint bin = 0;
                uint[] dec = new uint[4];

                for (int i = 0; i < 4; i++)
                {

                    byte tmp = Convert.ToByte(dottedDecimalIndirizzo.Split(".")[i]);

                    if (tmp >= 0 && tmp <= 255)
                        dec[i] = tmp;
                }

                for (int i = 0; i < 4; i++)
                {
                    int pos = 24 - (8 * i);
                    uint tmp = dec[i] << pos;
                    bin |= tmp;
                }



                indirizzo = bin;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public uint GetIndirizzo()
        {
            return indirizzo;
        }
    }

}
