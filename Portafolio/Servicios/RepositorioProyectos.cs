using Portafolio.Models;

namespace Portafolio.Servicios
{

    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyecto();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto>
            {
                new Proyecto
                {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado con ASP.NET Core",
                    Link = "https://amazon.com",
                    ImagenURL = "/imagenes/amazon.PNG"

                },
                 new Proyecto
                {
                    Titulo = "New York Times",
                    Descripcion = "E-Commerce realizado con ASP.NET Core",
                    Link = "https://nyt.com",
                    ImagenURL = "/imagenes/nyt.PNG"

                },
                  new Proyecto
                {
                    Titulo = "Steam",
                    Descripcion = "E-Commerce realizado con ASP.NET Core",
                    Link = "https://store.steampowered.com",
                    ImagenURL = "/imagenes/steam.PNG"

                }
            };


        }
    }
}
