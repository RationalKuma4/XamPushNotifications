using System.Collections.Generic;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Prism;
using Prism.Ioc;
using PushNotMob.ViewModels;
using PushNotMob.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PushNotMob
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);
            OneSignal.Current.StartInit("xxxxxxxxxxxxx")
                .Settings(new Dictionary<string, bool>
                {
                    { IOSSettings.kOSSettingsKeyAutoPrompt, false },
                    { IOSSettings.kOSSettingsKeyInAppLaunchURL, false }
                })
                .InFocusDisplaying(OSInFocusDisplayOption.Notification)
                .EndInit();

            OneSignal.Current.RegisterForPushNotifications();

            // Get the playerId assigned to the device
            // Save it in the storage to work with it later
            var playerId = await OneSignal.Current.IdsAvailableAsync();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
