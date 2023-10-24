using System;
using System.Drawing;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterTwitter : IFilter
    {
        public TwitterImage publisher;
        public string postDescription;
        public string pathToImage;
        public IPicture Filter(IPicture image)
        {
            Console.WriteLine(publisher.PublishToTwitter(this.postDescription, this.pathToImage));
            return image;
        }
    }
}