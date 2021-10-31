#region Using derectives

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Domain.Entity;
using TestTask.Shared;

#endregion

namespace TestTask.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IPhotoRepository _photoRepository;

        public PhotosController(ILogger<PhotosController> logger, IPhotoRepository photoRepository)
        {
            _logger = logger;
            _photoRepository = photoRepository;
        }

        //GET Photos/
        [HttpGet]
        public async Task<List<Photo>> Get() => await _photoRepository.GetPhotoListAsync();

        //GET Photos/{id}
        [HttpGet("{id}")]
        public async Task<Photo> GetPhoto(int id) => await _photoRepository.GetPhotoAsync(id);

        //POST Photos/
        [HttpPost]
        public async Task Post(Photo photo)
        {
            await _photoRepository.CreateAsync(photo);
            await _photoRepository.SaveAsync();
        }

        //DELETE Photos/{id}
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _photoRepository.DeleteAsync(id);
            await _photoRepository.SaveAsync();
        }

        //PUT Photos/
        [HttpPut]
        public async Task Put(Photo photo)
        {
            if (await _photoRepository.IsExists(photo))
                await _photoRepository.UpdateAsync(photo);

            await _photoRepository.SaveAsync();
        }
    }
}