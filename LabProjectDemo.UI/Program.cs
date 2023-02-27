using LabProjectDemo.Core;
using LabProjectDemo.Core.Interfaces.Camera;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.Repositories;

namespace LabProjectDemo.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}