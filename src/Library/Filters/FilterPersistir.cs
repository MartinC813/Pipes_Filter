using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterPersistir : IFilter
    {
        public string referencia;
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, $"C:\\Users\\tinch\\OneDrive\\Escritorio\\{this.referencia}.jpg");
            return image;
        }
    }
}
