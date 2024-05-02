using eventPlannerBack.Models.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace eventPlannerBack.BLL.Service
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySetting> config)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            try
            {
                var uploadResult = new ImageUploadResult();
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    //Transformation= new Transformation().Height(500).Width(500).Crop("fill")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);

                var Url = uploadResult.SecureUrl.AbsoluteUri;
                return Url;
            }
            catch (Exception) { throw; }
        }
    }
}
