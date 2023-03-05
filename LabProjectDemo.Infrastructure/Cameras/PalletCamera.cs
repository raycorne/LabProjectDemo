using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Infrastructure.Cameras
{
    public class PalletCamera : Camera
    {
        private readonly IMarkcodeService<PalletMarkcode> _markcodeService;
        public PalletCamera(ICameraNetworkModule cameraNetworkModule, ICameraCodeDecoder codeDecoder,
            IMarkcodeService<PalletMarkcode> markcodeService, IVeiwController viewController)
            : base(cameraNetworkModule, codeDecoder, viewController)
        {
            _markcodeService = markcodeService;
        }
    }
}
