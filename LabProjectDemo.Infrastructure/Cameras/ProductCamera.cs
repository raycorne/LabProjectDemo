using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Infrastructure.Cameras
{
    public class ProductCamera : Camera
    {
        private readonly IMarkcodeService<ProductMarkcode> _markcodeService;    // MarkcodeService
        public ProductCamera(ICameraNetworkModule cameraNetworkModule, ICameraCodeDecoder codeDecoder,
            IMarkcodeService<ProductMarkcode> markcodeService, IVeiwController viewController)
            : base(cameraNetworkModule, codeDecoder, viewController)
        {
            _markcodeService = markcodeService;
        }
    }
}
