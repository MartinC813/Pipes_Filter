using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeCondicional : IPipe
    {
        protected IPipe pipeFalse;
        protected IPipe pipeTrue;
        protected FilterCondicional filtro;
        /// <summary>
        /// Debido a que Filtro condicional esta attached a pipecondicional ambas funcionan juntas, sino, no funcionan.
        /// </summary>
        public bool cara
        {
            get{return false;}
        }
        public PipeCondicional(FilterCondicional nextFiltro, IPipe nextPipeTrue, IPipe nextPipeFalse)
        {
            this.pipeTrue = nextPipeTrue;
            this.pipeFalse = nextPipeFalse;
            this.filtro = nextFiltro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.pipeTrue; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            if (this.filtro.cara == true)
            {
                return this.pipeTrue.Send(picture);
            }
            else
            {
                return this.pipeFalse.Send(picture);
            }
        }
    }
}
