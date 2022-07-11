using Business.Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Interfaces
{
    public interface IPaintingService
    {
        Task<PaintingDTO> GetByIdAsync(string id);
        Task<List<PaintingDTO>> GetAllAsync();
        Task AddNewPaintingAsync(PaintingDTO data);
        Task UpdatePaintingAsync(PaintingDTO data);
        Task DeleteAsync(string id);
    }
}
