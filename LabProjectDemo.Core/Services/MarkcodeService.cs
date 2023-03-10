﻿using LabProjectDemo.Core.DTO;
using LabProjectDemo.Core.Interfaces.Markcodes;

namespace LabProjectDemo.Core.Services
{
    public class MarkcodeService : IMarkcodeService
    {
        public readonly IMarkcodeRepository _markcodeRepository;

        public MarkcodeService(IMarkcodeRepository markcodeRepository)
        {
            _markcodeRepository = markcodeRepository;
        }

        public void AddMarkcode(MarkcodeDTO markcode)
        {
            _markcodeRepository.AddMarkcode(markcode);
        }

        public void DeleteMarkcodeById(string id)
        {
            _markcodeRepository.DeleteMarkcodeById(id);
        }

        public List<MarkcodeDTO> GetAllMarkcodes()
        {
            return _markcodeRepository.GetAllMarkcodes();
        }

        public MarkcodeDTO GetMarkcode(string id)
        {
            return _markcodeRepository.GetMarkcode(id);
        }
    }
}
