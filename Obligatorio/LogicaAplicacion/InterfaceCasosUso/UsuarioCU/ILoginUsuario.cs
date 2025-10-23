﻿using Compartido.DTOs.UsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.UsuarioCU
{
    public interface ILoginUsuario
    {
        UsuarioLogueadoDTO Ejecutar(string email, string contrasenia);
    }
}
