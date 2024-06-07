using Ioio.Lib.Api;
using Ioio.Lib.Util;

namespace SampleIoIo
{
	public class IoIoLooper : BaseIOIOLooper
	{
		IDigitalOutput? digitalOutput;
		bool state = false;
		bool isRunning = false;

		protected override void Setup()
		{
			Console.WriteLine("IOIO connected, Setup");

			// On board LED control
			digitalOutput = Ioio?.OpenDigitalOutput(0, true);

			isRunning = true;
		}

		public void ToggleRelay()
		{
			Console.WriteLine("IOIO toggle");
			state = !state;
			digitalOutput?.Write(state);
		}

		public override void Loop()
		{
			// Loop IOIO
			while (isRunning)
			{
				ToggleRelay();

				Thread.Sleep(1000);
			}
		}

		public override void Disconnected()
		{
			isRunning = false;
			base.Disconnected();
			Console.WriteLine("IOIO disconnected");
		}
	}
}
