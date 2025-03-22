using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using LMSCapstone.Models;
using LMSCapstone.Repositories;

namespace LMSCapstone.Services
{
    public interface IVideoService
    {
        Task<ServiceResult> UploadVideoAsync(VideoUploadModel model);
        Task<Stream> GetVideoStreamAsync(int videoId);
    }

    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ServiceResult> UploadVideoAsync(VideoUploadModel model)
        {
            if ((model.Video == null || model.Video.Length == 0) && string.IsNullOrWhiteSpace(model.RemoteUrl))
            {
                return new ServiceResult { Success = false, Message = "No video file or URL provided.", Data = null };
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedVideos");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            Stream fileStream = null;
            string originalFileName = null;

            if (model.Video != null && model.Video.Length > 0)
            {
                fileStream = model.Video.OpenReadStream();
                originalFileName = model.Video.FileName;
            }
            else if (!string.IsNullOrWhiteSpace(model.RemoteUrl))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        fileStream = await client.GetStreamAsync(model.RemoteUrl);
                        originalFileName = Path.GetFileName(new Uri(model.RemoteUrl).LocalPath);
                    }
                    catch (Exception ex)
                    {
                        return new ServiceResult { Success = false, Message = "Failed to download file from remote URL: " + ex.Message, Data = null };
                    }
                }
            }

            if (fileStream == null)
            {
                return new ServiceResult { Success = false, Message = "Unable to obtain video stream.", Data = null };
            }

            var fileName = Path.GetFileName(originalFileName);
            var uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{Guid.NewGuid()}{Path.GetExtension(fileName)}";
            var filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var outputStream = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(outputStream);
            }

            string relativePath = Path.Combine("UploadedVideos", uniqueFileName);
            var videoModel = new Video
            {
                CourseId = model.CourseId,
                Url = relativePath,
                Title = originalFileName
            };

            await _videoRepository.AddAsync(videoModel);

            return new ServiceResult { Success = true, Message = "Video uploaded successfully.", Data = videoModel };
        }

        public async Task<Stream> GetVideoStreamAsync(int videoId)
        {
            var videoModel = await _videoRepository.GetByIdAsync(videoId);
            if (videoModel == null)
                return null;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), videoModel.Url);
            if (!File.Exists(filePath))
                return null;

            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
    }
}
