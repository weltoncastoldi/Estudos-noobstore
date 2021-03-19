using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NoobStore.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

    }
}
