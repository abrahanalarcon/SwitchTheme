namespace SwitchTheme
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool isDarkMode = false; 

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnThemeToggled(object sender, ToggledEventArgs e)
        {
            isDarkMode = e.Value;
            ApplyTheme(isDarkMode);

            
        }

        private void ApplyTheme(bool darkMode)
        {
            var resources = Application.Current.Resources;

            if (darkMode)
            {
                resources["DynamicPrimaryColor"] = resources["PrimaryColorDark"];
                resources["DynamicSecondaryColor"] = resources["SecondaryColorDark"];
                resources["DynamicTextColor"] = resources["TextColorDark"];
                resources["DynamicBackgroundColor"] = resources["BackgroundColorDark"];
            }
            else
            {
                resources["DynamicPrimaryColor"] = resources["PrimaryColor"];
                resources["DynamicSecondaryColor"] = resources["SecondaryColor"];
                resources["DynamicTextColor"] = resources["TextColor"];
                resources["DynamicBackgroundColor"] = resources["BackgroundColor"];
            }
        }
    }
}