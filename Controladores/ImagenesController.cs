using Microsoft.AspNetCore.Mvc;
using TACOSImagenesAPI.Negocio;

namespace TACOSImagenesAPI.Controladores;
[ApiController]
[Route("[controller]")]
public class ImagenesController : ControllerBase
{

    private readonly ILogger<ImagenesController> logger;
    private IImagenMgt imgMgr;
    public ImagenesController(ILogger<ImagenesController> logger,
                             IImagenMgt imgMgr)
    {
        this.logger = logger;
        this.imgMgr = imgMgr;
    }


    [HttpPost(Name = "ObtenerImagenesEn")]


    public IActionResult ObtenerImagenesEn([FromBody] HashSet<int> rangoDeIds)
    {
        try
        {
            return new JsonResult(this.imgMgr.ObtenerImagenesEn(rangoDeIds)) { StatusCode = 200 };
        }
        catch (Exception ex) 
        {
            string mensaje = "";
            switch (ex.Message)
            {
                default:
                    mensaje = "No hay conexión con la base de datos.";
                    break;
            }
            return new JsonResult(new { mensaje }) { StatusCode = Int32.Parse(ex.Message) };
        }
    }


}
