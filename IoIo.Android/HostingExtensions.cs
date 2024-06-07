using Android.App;
using Android.Content;
using Ioio.Lib.Util;
using Ioio.Lib.Util.Android;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;

namespace IoIo.Android.Util
{
	public static class HostingExtensions
	{
		public static MauiAppBuilder UseIoIo<TLooper>(this MauiAppBuilder builder)
			where TLooper : BaseIOIOLooper
		{
			// Register the IOIO looper
			builder.Services.AddSingleton<TLooper>();

			// Register the IOIO looper provider
			builder.Services.AddSingleton<IOIOLooperProvider>(sp =>
				new MauiIOIOLooperProvider(sp.GetRequiredService<TLooper>()));

			builder.Services.AddSingleton<MauiIOIOHelper>();

			builder.ConfigureLifecycleEvents(lifecycle =>
			{
				lifecycle.AddAndroid(android =>
				{
					android.OnCreate((activity, bundle) => {

						var appHelper = activity.GetService<MauiIOIOHelper>();
						Console.WriteLine("OnCreate");
						appHelper?.Initialize(activity, activity.GetService<IOIOLooperProvider>());
						Console.WriteLine("Initialize App Helper");
						appHelper?.Create();
						Console.WriteLine("Create");
					});

					android.OnStop((activity) => activity.GetService<MauiIOIOHelper>()?.OnStop());

					android.OnDestroy((activity) => activity.GetService<MauiIOIOHelper>()?.OnDestroy());

					android.OnStart((activity) => activity.GetService<MauiIOIOHelper>()?.OnStart());

					android.OnNewIntent((activity, intent) => activity.GetService<MauiIOIOHelper>()?.OnNewIntent(intent));
				});
			});

			return builder;
		}

		static T? GetService<T>(this Activity activity) where T : class
		{
			var s = global::Microsoft.Maui.MauiApplication.Current?.Services?.GetService<T>();
			return s;

		}

		internal class MauiServiceProvider : IMauiInitializeService
		{
			public static IServiceProvider Services { get; private set; } = null!;
			public void Initialize(IServiceProvider services)
			{
				Services = services;
			}
		}
	}
}