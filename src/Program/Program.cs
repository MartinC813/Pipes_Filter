using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;
using Ucu.Poo.Cognitive;
namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("beer.jpg");
            ///Ejercicio 1
            PipeNull serialNull = new PipeNull();
            FilterGreyscale Gris = new FilterGreyscale();
            FilterNegative Negativo = new FilterNegative();
            PipeSerial Serial = new PipeSerial(Negativo, serialNull);
            PipeSerial SerialEjercicio = new PipeSerial(Gris, Serial);
            provider.SavePicture(SerialEjercicio.Send(picture), "C:\\Users\\tinch\\OneDrive\\Escritorio\\luke3.jpg");

            ///Ejercicio 2
            /*
            FilterPersistir p1 = new FilterPersistir(provider);
            p1.referencia = "Intermedio";
            FilterPersistir p2 = new FilterPersistir(provider);
            p2.referencia = "Intermedio2";
            PipeSerial Serial2 = new PipeSerial(Negativo, Null);
            PipeSerial SerialGuardar = new PipeSerial(p1, Serial2);
            PipeSerial SerialEjercicio2 = new PipeSerial(Gris, SerialGuardar);
            p2.Filter(SerialEjercicio2.Send(picture));
            */

            ///Ejercicio 3
            /*
            var twitter = new TwitterImage();
            FilterPersistir p1 = new FilterPersistir(provider);
            p1.referencia = "Intermedio";
            FilterPersistir p2 = new FilterPersistir(provider);
            p2.referencia = "Intermedio2";
            FilterTwitter publicador1 = new FilterTwitter();
            publicador1.pathToImage = $"{p1.referencia}.jpg";
            publicador1.postDescription = "Imagen1";            ///Crea los path
            publicador1.publisher = twitter;
            FilterTwitter publicador2 = new FilterTwitter();
            publicador2.pathToImage = $"{p2.referencia}.jpg";
            publicador2.postDescription = "Publicador2";        ///Crea las descripciones
            publicador2.publisher = twitter;
            PipeSerial SerialTwitter2 = new PipeSerial(p2, Null);
            PipeSerial Serial2 = new PipeSerial(Negativo, SerialTwitter2);
            PipeSerial SerialGuardar = new PipeSerial(publicador1, Serial2);
            PipeSerial SerialTwitter1 = new PipeSerial(p1, SerialGuardar);
            PipeSerial SerialEjercicio2 = new PipeSerial(Gris, SerialTwitter1);
            publicador2.Filter(SerialEjercicio2.Send(picture));
            */

            ///Ejercicio 4
            CognitiveFace cog = new CognitiveFace(false);
            FilterPersistir p1 = new FilterPersistir(provider);
            p1.referencia = "Ejercicio4ConCara";
            FilterCondicional condicional = new FilterCondicional();
            condicional.cog = cog;
            condicional.path = ("beer.jpg");
            PipeSerial serialNeg = new PipeSerial(Negativo, serialNull);
            PipeSerial serialTwitter2 = new PipeSerial(p1, serialNull);
            PipeCondicional serialConcicional = new PipeCondicional(condicional, serialTwitter2, serialNeg);
            PipeSerial serialGris = new PipeSerial(Gris, serialConcicional);
            p1.Filter(serialGris.Send(picture));
        }
    }
}