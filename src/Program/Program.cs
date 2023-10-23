using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("luke.jpg");
            ///Ejercicio 1
            PipeNull Null = new PipeNull();
            FilterGreyscale Gris = new FilterGreyscale();
            FilterNegative Negativo = new FilterNegative();
            PipeSerial Serial = new PipeSerial(Negativo, Null);
            PipeSerial SerialEjercicio = new PipeSerial(Gris, Serial);
            provider.SavePicture(SerialEjercicio.Send(picture), "C:\\Users\\tinch\\OneDrive\\Escritorio\\luke3.jpg");
            ///Ejercicio 2
            FilterPersistir p1 = new FilterPersistir(provider);
            p1.referencia = "Intermedio";
            FilterPersistir p2 = new FilterPersistir(provider);
            p2.referencia = "Intermedio2";
            PipeSerial Serial2 = new PipeSerial(Negativo, Null);
            PipeSerial SerialGuardar = new PipeSerial(p1, Serial2);
            PipeSerial SerialEjercicio2 = new PipeSerial(Gris, SerialGuardar);
            p2.Filter(SerialEjercicio2.Send(picture));
        }
    }
}
