using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config", Watch = true)]

namespace GSTBill
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            base.OnStartup(e);

            //
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            BakerSoft.AutoMapperConfig.Configure();

            //IMapper Mapper = BakerSoft.AutoMapperConfig.MapperConfiguration.CreateMapper();
        }
    }
}
