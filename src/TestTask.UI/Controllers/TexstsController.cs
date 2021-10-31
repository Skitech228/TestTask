#region Using derectives

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Domain.Entity;
using TestTask.Shared;
using TestTask.Shared.IEntityServices;

#endregion

namespace TestTask.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TexstsController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly ITextRepository _textRepository;
        private readonly ITextService _textService;

        public TexstsController(ILogger<PhotosController> logger, ITextRepository textRepository, ITextService textService)
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

        ////GET Texts/
        //[HttpPost]
        //public async Task<byte[]> GetTextInCsv()
        //{
        //    byte[] data;

        //    using (MemoryStream stream = new MemoryStream())
        //        using (TextWriter textWriter = new StreamWriter(stream))
        //            using (CsvWriter csv = new CsvWriter(textWriter, new CsvConfiguration(new CultureInfo(0))))
        //            {
        //                await csv.WriteRecordsAsync(await _textRepository.GetTextListAsync());
        //                await textWriter.FlushAsync();
        //                data = stream.ToArray();
        //            }

        //    return data;
        //}

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
        [HttpHead]
        public async Task<IActionResult> File()
        {
            _textService.WriteCSVFile(Request.Path,await _textRepository.GetTextListAsync());  

            return PhysicalFile(Request.Path,"csv");
        }
    }
}