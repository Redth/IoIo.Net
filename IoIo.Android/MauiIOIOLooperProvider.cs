using Android.OS;
using Ioio.Lib.Api;
using Ioio.Lib.Util;

namespace IoIo.Android.Util
{
	public class MauiIOIOLooperProvider : Java.Lang.Object, IOIOLooperProvider
	{
		public MauiIOIOLooperProvider(BaseIOIOLooper looper)
		{
			Looper = looper;
		}

		public readonly BaseIOIOLooper Looper;

		public IOIOLooper? CreateIOIOLooper(string? connectionType, Java.Lang.Object? extra)
		{
			return Looper;
		}


	}
}