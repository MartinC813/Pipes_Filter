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
           ejercicio1();
           ejercicio2();
           ejercicio3();
           ejercicio4();

        }


        public static void ejercicio1()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("beer.jpg");
            ///Creo los filtros
            FilterGreyscale Gris = new FilterGreyscale();
            FilterNegative Negativo = new FilterNegative();
            ///Creo las pipes
            PipeNull serialNull = new PipeNull();
            PipeSerial Serial = new PipeSerial(Negativo, serialNull);
            PipeSerial SerialEjercicio = new PipeSerial(Gris, Serial);

            ///Run
            provider.SavePicture(SerialEjercicio.Send(picture), "C:\\Users\\tinch\\OneDrive\\Escritorio\\luke3.jpg");
        }
        public static void ejercicio2()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("beer.jpg");

            ///Crea los filtros
            FilterGreyscale gris = new FilterGreyscale();
            FilterNegative negativo = new FilterNegative();
            FilterPersistir p1 = new FilterPersistir(provider);   
            FilterPersistir p2 = new FilterPersistir(provider);

            ///Las referencias seran los path de las imagenes guardadas
            p1.referencia = "Ejercicio2Foto1";   
            p2.referencia = "Ejercicio2Foto2";

            ///Creo los pipes
            PipeNull serialNull = new PipeNull();
            PipeSerial Serial2 = new PipeSerial(negativo, serialNull);
            PipeSerial SerialGuardar = new PipeSerial(p1, Serial2);
            PipeSerial SerialEjercicio2 = new PipeSerial(gris, SerialGuardar);

            ///Run
            p2.Filter(SerialEjercicio2.Send(picture));
        }
        public static void ejercicio3()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("luke.jpg");
            var twitter = new TwitterImage();

            ///Creo los filtros
            FilterGreyscale gris = new FilterGreyscale();
            FilterNegative negativo = new FilterNegative();
            FilterPersistir p1 = new FilterPersistir(provider);
            FilterPersistir p2 = new FilterPersistir(provider);

            ///Las referencias seran los path de las imagenes guardadas
            p1.referencia = "Ejercicio3Foto1";
            p2.referencia = "Ejercicio3Foto2";

            ///Crea los filtros para publicar en tw
            FilterTwitter publicador1 = new FilterTwitter();
            FilterTwitter publicador2 = new FilterTwitter();

            ///Setea en las instancias los path de las imagenes y las post description
            publicador1.pathToImage = $"{p1.referencia}.jpg";
            publicador1.postDescription = "MC";        
            publicador1.publisher = twitter;
            publicador2.pathToImage = $"{p2.referencia}.jpg";
            publicador2.postDescription = "MC2";  
            publicador2.publisher = twitter;

            ///Crea los pipes
            PipeNull serialNull = new PipeNull();
            PipeSerial SerialTwitter2 = new PipeSerial(p2, serialNull);
            PipeSerial Serial2 = new PipeSerial(negativo, SerialTwitter2);
            PipeSerial SerialGuardar = new PipeSerial(publicador1, Serial2);
            PipeSerial SerialTwitter1 = new PipeSerial(p1, SerialGuardar);
            PipeSerial SerialEjercicio2 = new PipeSerial(gris, SerialTwitter1);

            ///Run
            publicador2.Filter(SerialEjercicio2.Send(picture));
        }
        public static void ejercicio4()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("luke.jpg");
            CognitiveFace cog = new CognitiveFace(false);

            ///Crea los filtros
            FilterGreyscale gris = new FilterGreyscale();
            FilterNegative negativo = new FilterNegative();
            FilterPersistir p1 = new FilterPersistir(provider);
            FilterCondicional condicional = new FilterCondicional();

            ///La referencia sera el path de la nueva imagen
            p1.referencia = "Ejercicio4ConCara";
            condicional.cog = cog;
            condicional.path = ("luke.jpg");

            ///Crea las pipes
            PipeNull serialNull = new PipeNull();
            PipeSerial serialNeg = new PipeSerial(negativo, serialNull);
            PipeSerial serialTwitter2 = new PipeSerial(p1, serialNull);
            PipeCondicional serialConcicional = new PipeCondicional(condicional, serialTwitter2, serialNeg);
            PipeSerial serialGris = new PipeSerial(gris, serialConcicional);

            ///Run
            p1.Filter(serialGris.Send(picture));
        }
    }
}