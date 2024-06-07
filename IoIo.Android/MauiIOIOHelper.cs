using Ioio.Lib.Util;
using Ioio.Lib.Util.Android;

namespace IoIo.Android.Util
{
	public class MauiIOIOHelper
	{
		IOIOAndroidApplicationHelper? appHelper;

		internal void Initialize(global::Android.App.Activity activity, IOIOLooperProvider? looperProvider)
		{
			appHelper = new IOIOAndroidApplicationHelper(activity, looperProvider);
		}

		public void Create()
		{
			appHelper?.Create();
		}

		public void OnStart()
		{
			appHelper?.Start();
		}

		public void OnStop()
		{
			appHelper?.Stop();
		}

		public void OnDestroy()
		{
			appHelper?.Destroy();
		}

		public void OnNewIntent(global::Android.Content.Intent? intent)
		{
			if (intent is not null && intent.Flags.HasFlag(global::Android.Content.ActivityFlags.NewTask))
				appHelper?.Restart();
		}
	}
}