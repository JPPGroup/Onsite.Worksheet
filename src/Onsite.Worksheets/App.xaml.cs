using Microsoft.Practices.Unity;
using Onsite.Worksheets.UILogic.Abstracts;
using Onsite.Worksheets.UILogic.Managers;
using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Onsite.Worksheets.Services;
using Onsite.Worksheets.UILogic;
using Onsite.Worksheets.UILogic.Proxies;
using Onsite.Worksheets.UILogic.Repositories;
using Onsite.Worksheets.UILogic.Services;
using Prism.Events;
using Prism.Windows.AppModel;


namespace Onsite.Worksheets
{
    public sealed partial class App : PrismUnityApplication
    {
        protected override UIElement CreateShell(Frame rootFrame)
        {
            var shell = Container.Resolve<AppShell>();
            shell.SetContentFrame(rootFrame);
            return shell;
        }


        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.Home.ToString(), null);
            return Task.FromResult(true);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            Container.RegisterInstance<IResourceLoader>(new ResourceLoaderAdapter(new ResourceLoader()));

            Container.RegisterType<INetworkManager, NetworkManager>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IAlertMessageService, AlertMessageService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INetworkStatusService, NetworkStatusService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IQueueStatusService, QueueStatusService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IRemoteStatusService, RemoteStatusService>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IInspectionService, InspectionServiceProxy>();
            Container.RegisterType<IStructureService, StructureServiceProxy>();
            Container.RegisterType<IProjectService, ProjectServiceProxy>();

            Container.RegisterType<IInspectionRepository, InspectionRepository>();
            Container.RegisterType<ISoakawayReportRepository, SoakawayReportRepository>();

            return base.OnInitializeAsync(args);
        }
    }
}
