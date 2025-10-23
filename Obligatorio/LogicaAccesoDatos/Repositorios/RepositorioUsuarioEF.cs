﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private ObligatorioContext Contexto { get; set; }

        public RepositorioUsuarioEF(ObligatorioContext contexto)
        {
            Contexto = contexto;
        }

        public void Alta(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario item)
        {
            Usuario usuarioBuscado = GetByEmail(item.Id, item.Email.Valor);

            if (usuarioBuscado == null)
            {
                Contexto.ChangeTracker.Clear();
                Contexto.Usuarios.Update(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new UsuarioException("Usuario ya existente");
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, string contrasenia)
        {
            Usuario ret = Contexto.Usuarios.Where(c => c.Email.Valor == email
            && c.Contrasenia.Valor == contrasenia).SingleOrDefault();

            if (ret == null)
            {
                throw new UsuarioException("Datos incorrectos");
            }

            return ret;
        }

        public Usuario GetByEmailUsuario(string email)
        {
            Usuario ret = Contexto.Usuarios.Where(c => c.Email.Valor == email).SingleOrDefault();
            return ret;
        }

        private Usuario GetByEmail(int id, string email)
        {
            Usuario ret = Contexto.Usuarios.Where(c => c.Id != id && c.Email.Valor == email).SingleOrDefault();

            if (ret != null)
            {
                throw new UsuarioException("Email incorrecto");
            }

            return ret;
        }

    }
}
