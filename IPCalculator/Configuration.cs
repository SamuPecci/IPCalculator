namespace IPCalculator
{
    class Configuration
    {
        IP ip;
        SubnetMask subnetMask;
        uint indirizzoBroadcast;
        uint indirizzoRete;
        uint primoHost;
        uint ultimoHost;

        public Configuration(string dottedDecimalIndirizzo, string dottedDecimalMaschera)
        {
            ip = new(dottedDecimalIndirizzo);
            subnetMask = new(dottedDecimalMaschera);
            indirizzoBroadcast = CalcolaIndirizzoBroadcast();
            indirizzoRete = CalcolaIndirizzoRete();
            primoHost = CalcolaPrimoHost();
            ultimoHost = CalcolaUltimoHost();
        }

        private uint CalcolaIndirizzoBroadcast()
        {
            return ip.GetIndirizzo() | ~subnetMask.GetMaschera();
        }

        private uint CalcolaIndirizzoRete()
        {
            return ip.GetIndirizzo() & subnetMask.GetMaschera();
        }

        private uint CalcolaPrimoHost()
        {
            return indirizzoRete + 1;
        }

        private uint CalcolaUltimoHost()
        {
            return indirizzoBroadcast - 2;
        }

        private string ConvertiIndirizzo(uint daConvertire)
        {
            byte[] indirizzo = new byte[4];
            uint mask = 0b11111111;

            for (int i = 0; i < 4; i++)
                indirizzo[i] = (byte)(daConvertire >> 8 * i & mask);

            return $"{indirizzo[3]}.{indirizzo[2]}.{indirizzo[1]}.{indirizzo[0]}";
        }

        public string GetIndirizzoIp()
        {
            return ConvertiIndirizzo(ip.GetIndirizzo());
        }

        public string GetMascheraDiSottorete()
        {
            return ConvertiIndirizzo(subnetMask.GetMaschera());
        }

        public string GetIndirizzoBroadcast()
        {
            return ConvertiIndirizzo(indirizzoBroadcast);
        }

        public string GetIndirizzoRete()
        {
            return ConvertiIndirizzo(indirizzoRete);
        }

        public string GetPrimoHost()
        {
            return ConvertiIndirizzo(primoHost);
        }

        public string GetUltimoHost()
        {
            return ConvertiIndirizzo(ultimoHost);
        }
    }

}
