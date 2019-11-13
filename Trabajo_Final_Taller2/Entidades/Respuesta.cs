﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Respuesta
    {
        public int IdRespuesta { get; set; }
        public int IdUserResp { get; set; }
        public int IdPregunta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public DateTime Fecha { get; set; }
        public int Likes { get; set; }
        public Usuario UserRespuesta { get; set; }
        public Pregunta PregRespuesta { get; set; }
    }
}
