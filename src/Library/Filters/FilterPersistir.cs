using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterPersistir : IFilter
    {
        /// <summary>
        /// Cumple DIP
        /// </summary>
        public string referencia;
        IPictureProvider provider;
        public FilterPersistir(IPictureProvider provider)
        {
            this.provider = provider;
        }
        public IPicture Filter(IPicture image)
        {
            this.provider.SavePicture(image, $"{this.referencia}.jpg");
            return image;
        }
    }
}