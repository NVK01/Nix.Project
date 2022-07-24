using AutoMapper;
using Business.Layer.DTO;
using Business.Layer.Interfaces;
using Data.Access.Layer.Entities;
using Data.Access.Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaintingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddNewPaintingAsync(PaintingDTO data)
        {
            var dataEntity = _mapper.Map<PaintingDTO, Painting>(data);

            await _unitOfWork.Paintings.AddAsync(dataEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = await GetByIdAsync(id);

            await _unitOfWork.Paintings.DeleteAsync(id);
        }

        public async Task<List<PaintingDTO>> GetAllAsync()
        {
            var paintings = await _unitOfWork.Paintings.GetAllAsync();

            return _mapper.Map<List<Painting>, List<PaintingDTO>>(paintings);
        }

        public async Task<PaintingDTO> GetByIdAsync(Guid id)
        {
            var paintings = await _unitOfWork.Paintings.GetByIdAsync(id);
            var data = _mapper.Map<Painting, PaintingDTO>(paintings);
            return data;
        }

        public async Task UpdatePaintingAsync(PaintingDTO data)
        {
            var dataEntity = _mapper.Map<PaintingDTO, Painting>(data);

            await _unitOfWork.Paintings.UpdateAsync(dataEntity);
        }
    }
}
