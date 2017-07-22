using System.Collections.Generic;
using System.Threading.Tasks;
using FaceDetectorApi.Models;

namespace FaceDetectorApi.Repositories
{
    public interface ITableRepository
    {
        Task InsertFace(FaceInfo face);
        Task<IEnumerable<FaceDto>> GetAllFaces();
    }
}
