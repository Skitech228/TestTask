#region Using derectives

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Application.Services;
using TestTask.Domain.Entity;
using TestTask.Shared.IEntityRepositories;

#endregion

namespace TestTask.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextsController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly ITextRepository _textRepository;
        private readonly TextService _textService;

        public TextsController(ILogger<PhotosController> logger,
                               ITextRepository textRepository,
                               TextService textService)
        {
            _logger = logger;
            _textRepository = textRepository;
            _textService = textService;
        }

        //GET Texts/
        [HttpGet]
        public async Task<List<Text>> Get() => await _textRepository.GetTextListAsync();

        //GET Texts/{id}
        [HttpGet("{id}")]
        public async Task<Text> GetText(int id) => await _textRepository.GetTextAsync(id);

        //POST Texts/
        [HttpPost]
        public async Task Post(Text text)
        {
            await _textRepository.CreateAsync(text);
            await _textRepository.SaveAsync();
        }

        //DELETE Texts/{id}
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _textRepository.DeleteAsync(id);
            await _textRepository.SaveAsync();
        }

        //PUT Texts/
        [HttpPut]
        public async Task Put(Text text)
        {
            if (await _textRepository.IsExists(text))
                await _textRepository.UpdateAsync(text);

            await _textRepository.SaveAsync();
        }

        [HttpGet]
        [Route("Export")]
        public async Task<string> File()
        {
            _textService.WriteCSVFile("1.txt", await _textRepository.GetTextListAsync());

            return await new StreamReader("1.txt").ReadToEndAsync();
        }
    }
}