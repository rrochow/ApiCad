using System;
using System.Collections.Generic;

namespace ApiCad.Entidades
{
    public class Plano_
    {
        public string _id
        {
            get;
            set;
        }

        public draw Plano
        {
            get;
            set;
        }

    }

    public class draw
    {
        public string name
        {
            get;
            set;
        }

        public string type_plan
        {
            get;
            set;
        }

        public List<objeto> objetos
        {
            get;
            set;
        }
    }

    public class objeto
    {
        public string tipo
        {
            get;
            set;
        }

        public dimensiones dimensiones
        {
            get;
            set;
        }

    }

    public class dimensiones
    {
        public int ancho
        {
            get;
            set;
        }

        public int largo
        {
            get;
            set;
        }

    }
}
