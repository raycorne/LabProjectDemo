using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.ProductionLines;
using LabProjectDemo.Infrastructure.ProductionLines.DTO;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure
{
    public class Startup
    {
        public bool isConfiguratedSuccess { get; private set; }
        public LineJsonDTO? LineConfiguration { get; set; }
        private ProductionLine _productionLine;
        private ProductionLineConfigurationBuilder _lineConfigurationBuilder;
        public Startup(ILineView lineView)
        {
            GetLinesConfigurationFromJson();
            //_productionLines = new();
            ConfigurateLines(lineView);
        }

        private void GetLinesConfigurationFromJson()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("devicesConfig.json")
                .Build();
            LineConfiguration = configuration.GetSection("Line").Get<LineJsonDTO>();
            if (LineConfiguration == null)
            {
                isConfiguratedSuccess = false;
                return;
            }
        }

        private void ConfigurateLines(ILineView lineView)
        {
            _lineConfigurationBuilder = new ProductionLineConfigurationBuilder(LineConfiguration, lineView);
            _productionLine = _lineConfigurationBuilder.GetBuildedProductionLine();
        }

        public ProductionLine GetConfiguretedProductionLine()
        {
            return _productionLine;
        }

    }
}
