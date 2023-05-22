namespace TACOSImagenesAPI.Negocio;

using TACOSImagenesAPI.Modelos;

public interface IImagenMgt
{
    public List<Imagen> ObtenerImagenesEn(HashSet<int> rangoDeIds);

}
