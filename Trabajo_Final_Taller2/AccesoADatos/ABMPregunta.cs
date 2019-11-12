﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class ABMPregunta
    {
        /// <summary>
        /// Selecciona todas las preguntas en la base de datos
        /// </summary>
        /// <returns></returns>
        List<Pregunta> GetPreguntas()
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            // Hacer consulta en la base de datos y cargar la lista

            return preguntas;
        }

        /// <summary>
        /// Selecciona las preguntas del usuario especifico en la base de datos
        /// </summary>
        /// <returns></returns>
        List<Pregunta> GetPreguntas(Usuario user)
        {
            List<Pregunta> preguntasDeUser = new List<Pregunta>();

            int idUser = user.IdUsuario;
            // Hacer consulta en la base de datos usando el idUser y cargar la lista

            return preguntasDeUser;
        }


    }
}