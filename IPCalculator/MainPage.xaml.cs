namespace IPCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Calculate(object sender, EventArgs e)
        {
            IPAddress.Placeholder = "Enter IP address";
            IPAddress.PlaceholderColor = default;
            SubnetMask.Placeholder = "Enter subnet mask";
            SubnetMask.PlaceholderColor = default;

            try
            {
                Configuration config = new(IPAddress.Text, SubnetMask.Text);

                NetworkAddress.Text = config.GetIndirizzoRete();
                BroadcastAddress.Text = config.GetIndirizzoBroadcast();
                FirstHost.Text = config.GetPrimoHost();
                LastHost.Text = config.GetUltimoHost();
            }
            
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Indirizzo IP non valido":
                        IPAddress.Text = "";
                        IPAddress.Placeholder = "Incorrect IP address";
                        IPAddress.PlaceholderColor = Colors.Red;
                        break;

                    case "Maschera di sottorete non valida":
                        SubnetMask.Text = "";
                        SubnetMask.Placeholder = "Incorrect subnet mask";
                        SubnetMask.PlaceholderColor = Colors.Red;
                        break;

                    default:
                        throw new Exception(ex.Message);
                }

                NetworkAddress.Text = "";
                BroadcastAddress.Text = "";
                FirstHost.Text = "";
                LastHost.Text = "";
            }
        }
    }

}
