using System;
using System.Drawing;
using Ucu.Poo.Twitter;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterCondicional : IFilter
    {
        public CognitiveFace cog;
        public bool cara;
        public string path;
        public IPicture Filter(IPicture image)
        {
            cog.Recognize(path);
            this.cara = cog.FaceFound;
            return image;
        }
    }
}