using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Service
{
    public interface IServices
    {
        Task<Result<List<Users>>> GetUsers(CancellationToken token);
        Task<Result<List<UserAlbums>>> GetAlbums(int id, CancellationToken token);
        //Task<Result<List<AlbumPhotos>>> GetUsersPhotos(int id, CancellationToken token);
    }
}
