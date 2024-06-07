namespace SampleIoIo
{
	public partial class MainPage : ContentPage
	{
		IoIoLooper? ioio;

		public MainPage(IoIoLooper looper)
		{
			ioio = looper;
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			ioio!.ToggleRelay();
		}
	}

}
