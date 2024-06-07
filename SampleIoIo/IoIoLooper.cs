using Ioio.Lib.Api;
using Ioio.Lib.Util;

namespace SampleIoIo
{
	public class IoIoLooper : BaseIOIOLooper
	{
		IDigitalOutput? digitalOutput;
		bool state = false;

		protected override void Setup()
		{
			Console.WriteLine("IOIO connected, Setup");

			// On board LED control
			digitalOutput = Ioio?.OpenDigitalOutput(1, true);
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
			while (true)
			{
				ToggleRelay();
				Thread.Sleep(1000);
			}
		}

		public override void Disconnected()
		{
			base.Disconnected();
			Console.WriteLine("IOIO disconnected");
		}
	}
}
