using System.Globalization;
using TACOSImagenesAPI.Modelos;

namespace TACOSImagenesAPI.Negocio;



public class ImagenMgr : IImagenMgt
{

    protected TacosimagenesContext TACOSIMGContext;

    public ImagenMgr(TacosimagenesContext tacosImgContext)
    {
        string culture = "es-MX";
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
        this.TACOSIMGContext = tacosImgContext;
    }


    public List<Imagen> ObtenerImagenesEn(HashSet<int> rangoDeIds)
    {
        List<Imagen> imagenesObtenidas = (from imagen in this.TACOSIMGContext.Imagenes
                                          where rangoDeIds.Any(id => id == imagen.Id)
                                          select imagen
                                          ).ToList();
        return imagenesObtenidas;
    }
}
