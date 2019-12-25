using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Service.Implement
{
    public class Services : IServices
    {
        public async Task<Result<List<UserAlbums>>> GetAlbums(int id, CancellationToken token)
        {
            try
            {
                var apiClient = new ApiClient(AppConstants.HttpClientInstance);
                var route = $"/albums?userId={id}";
                var response = await apiClient.Get<List<UserAlbums>>(token, route);
                return response;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
        }

        //public async Task<Result<List<AlbumPhotos>>> GetUsersPhotos(int id, CancellationToken token)
        //{
        //    try
        //    {
        //        var apiClient = new ApiClient(AppConstants.HttpClientInstance);
        //        var route = $"/photos?albumId={id}";
        //        var response = await apiClient.Get<List<AlbumPhotos>>(token, route);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;
        //        return null;
        //    }
        //}

        public async Task<Result<List<Users>>>GetUsers(CancellationToken token)
        {
            try
            {
                var apiClient = new ApiClient(AppConstants.HttpClientInstance);
                var route = $"/users";
                var response = await apiClient.Get<List<Users>>(token, route);
                return response;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }
        }

       
    }
}
