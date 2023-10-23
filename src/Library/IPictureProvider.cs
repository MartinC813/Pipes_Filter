using System;
using System.Drawing;

namespace CompAndDel
{
    /// <summary>
    /// Representa una imagen. Las imagenes son una matriz bidimensional de colores. Adicionalmente, se proveen
    /// operaciones para obtener las dimensiones de la imagen, modificar el tamaño de la imagen, y copiar la imagen a una
    /// nueva.
    /// </summary>
    public interface IPictureProvider
    {
        IPicture GetPicture(string path);
        void SavePicture(IPicture picture, string path);

    }
}