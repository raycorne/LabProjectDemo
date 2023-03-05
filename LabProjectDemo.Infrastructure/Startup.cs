using LabProjectDemo.Infrastructure.ProductionLines;
using LabProjectDemo.Infrastructure.ProductionLines.DTO;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure
{
    public class Startup
    {
        public bool isConfiguratedSuccess { get; private set; }
        public MainLinesCfgJsonDTO? LinesConfiguration { get; set; }
        public List<ProductionLine> ProductionLines { get; set; } = new();
        private ProductionLineConfigurationBuilder _lineConfigurationBuilder;

        public Startup()
        {
            GetLinesConfigurationFromJson();
            ConfigurateLines();
        }

        public void GetLinesConfigurationFromJson()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("devicesConfig.json")
                .Build();
            LinesConfiguration = configuration.GetSection("LinesConfiguration").Get<MainLinesCfgJsonDTO>();
            if (LinesConfiguration == null)
            {
                isConfiguratedSuccess = false;
                return;
            }
        }

        public void ConfigurateLines()
        {
            foreach (var line in LinesConfiguration.Lines)
            {
                _lineConfigurationBuilder = new ProductionLineConfigurationBuilder(line);
                ProductionLines.Add(_lineConfigurationBuilder.GetBuildedProductionLine());
            }
        }

    }
}
