using APIDiary.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntradaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
