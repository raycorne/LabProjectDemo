using LabProjectDemo.Core.Entities;
using LabProjectDemo.Core.Interfaces.Cameras;
using LabProjectDemo.Core.Interfaces.Markcodes;
using LabProjectDemo.Infrastructure.Interfaces;

namespace LabProjectDemo.Infrastructure.Cameras
{
    public class BoxCamera : Camera
    {
        private readonly IMarkcodeService _markcodeService;
        public BoxCamera(ICameraNetworkModule cameraNetworkModule, ICameraCodeDecoder codeDecoder,
            IMarkcodeService markcodeService, IMainView viewController)
            : base(cameraNetworkModule, codeDecoder, viewController)
        {
            _markcodeService = markcodeService;
        }
    }
}
