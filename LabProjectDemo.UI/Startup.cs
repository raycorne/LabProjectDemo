﻿using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Services;
using LabProjectDemo.Core.Services.Camera;
using LabProjectDemo.Infrastructure.Cameras;
using LabProjectDemo.Infrastructure.Interfaces;
using LabProjectDemo.Infrastructure.NetworkConnector;
using LabProjectDemo.Infrastructure.Repositories;

namespace LabProjectDemo.UI
{
    public class Startup
    {
        IVeiwController _viewController;

        public Startup(IVeiwController veiwController)
        {
            _viewController = veiwController; 
        }

        public ProductCamera[] ConfigurateProductCameras()
        {
            return new ProductCamera[]
            {
                new ProductCamera(new CameraTCPConnector("127.0.0.1", 8888),
                new CameraCodeDecoderService(), new MarkcodeService<ProductMarkcode>(new ProductMarkcodeRepository()),
                _viewController)
            };
        }
    }
}
