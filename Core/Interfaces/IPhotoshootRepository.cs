using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhotoshootRepository
    {
        Task<Photoshoot> GetPhotoshootByIdAsync(int id);
        Task<IReadOnlyList<Photoshoot>> GetProductsAsync();
    }
}
