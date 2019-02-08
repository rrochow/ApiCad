using System;
namespace ApiCad.Entidades
{
    public class User
    {
        public string _id
        {
            get;
            set;
        }

        public _usuario usuario
        {
            get;
            set;
        }

    }
    public class _usuario
    {

        public string Nombre
        {
            get;
            set;
        }

        public string Apellido
        {
            get;
            set;
        }

        public string Dni
        {
            get;
            set;
        }

        public DateTime Fecha_creacion
        {
            get;
            set;
        }

        public int Estado
        {
            get;
            set;
        }

        public int Rol
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string contraseña
        {
            get;
            set;
        }
    }

}
