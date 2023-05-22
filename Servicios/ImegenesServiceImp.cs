namespace TACOSImagenesAPI.Servicios;

using Grpc.Core;
using Saludo;
using static Saludo.ImagenesService;
using TACOSImagenesAPI.Negocio;
using TACOSImagenesAPI.Modelos;
using Google.Protobuf;

public class ImegenesServiceImp : ImagenesServiceBase
{

    public override Task<ImagenesResponse> ObtenerImagenes(ImagenesRequest request, ServerCallContext context)
    {
        List<Modelos.Imagen> imagenesObtenidas = new List<Modelos.Imagen> { };
        using (var contexto = new Modelos.TacosimagenesContext())
        {
            imagenesObtenidas = 
                new ImagenMgr(contexto).ObtenerImagenesEn(request.Id.ToHashSet<int>());
        }

        List<Saludo.Imagen> imagenesConvertidas = new List<Saludo.Imagen>();
        foreach (Modelos.Imagen imagenObtenida in imagenesObtenidas)
        {
            imagenesConvertidas.Add(new Saludo.Imagen
            {
                Id = imagenObtenida.Id,
                Imagen_ = ByteString.CopyFrom(imagenObtenida.ImagenBytes),
                Nombre = imagenObtenida.Nombre
            });
        }

        ImagenesResponse response = new ImagenesResponse();
        response.Imagen.AddRange(imagenesConvertidas);
        return Task.FromResult(response);
    }
}
