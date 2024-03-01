using Microsoft.AspNetCore.Mvc;
using ApplicationException = Application.Exceptions.ApplicationException;

namespace GestionInventario.Api.Base
{
    public class BaseController : ControllerBase
    {
        public BaseController(){}

        public async Task<IActionResult> HandleRequestAsync<TResult>(Func<Task<TResult>> func)
        {
            try
            {
                TResult result = await func();
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
