using HelpURL.Application.Interfaces;
using HelpURL.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpURL.WebApi.Controllers
{
    [ApiController]
    [Route("url")]
    public  sealed class URLController : ControllerBase
    {
        private readonly IURLService _urlServices;

        public URLController(IURLService urlServices)
        {
            _urlServices = urlServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
      => Ok(await _urlServices.GetAll());

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] RequestUrlViewModel viewModel)
        {
            try
            {
                return Ok(await _urlServices.Create(viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] RequestUrlViewModel viewModel, Guid id)
        {
            try
            {
                return Ok(await _urlServices.Edit(id, viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _urlServices.Delete(id))
                    return Ok("URL deletado com sucesso.");

                return BadRequest("Ocorreu um erro ao deletar a URL.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
