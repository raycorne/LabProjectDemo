﻿using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.Interfaces.UIs;
using LabProjectDemo.Infrastructure.ProductionLines;
using LabProjectDemo.Infrastructure.ProductionLines.DTO;
using Microsoft.Extensions.Configuration;

namespace LabProjectDemo.Infrastructure
{
    public class Startup
    {
        public bool isConfiguratedSuccess { get; private set; }
        public MainLinesCfgJsonDTO? LinesConfiguration { get; set; }
        private List<ProductionLine> _productionLines = new();
        private ProductionLineConfigurationBuilder _lineConfigurationBuilder;
        public Startup(ILineView lineView)
        {
            GetLinesConfigurationFromJson();
            _productionLines = new();
            ConfigurateLines(lineView);
        }

        private void GetLinesConfigurationFromJson()
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

        private void ConfigurateLines(ILineView lineView)
        {
            foreach (var line in LinesConfiguration.Lines)
            {
                _lineConfigurationBuilder = new ProductionLineConfigurationBuilder(line, lineView);
                _productionLines.Add(_lineConfigurationBuilder.GetBuildedProductionLine());
            }
        }

        public List<ProductionLine> GetConfiguretedProductionLines()
        {
            return _productionLines;
        }

    }
}
