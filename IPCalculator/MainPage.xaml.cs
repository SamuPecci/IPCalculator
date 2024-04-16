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
            Configuration config = new(IPAddress.Text, SubnetMask.Text);


            CalculateBtn.Text = config.GetIndirizzoRete();
            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
