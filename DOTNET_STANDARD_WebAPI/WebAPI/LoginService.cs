//-----------------------------------------------------------------------
// <copyright file="LoginService.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class LoginService
    {
        public static bool Login(string login, string senha)
        {
            using (FuncionariosDBContext entities = new FuncionariosDBContext())
            {
                return entities.Usuarios.Any(user =>
               user.Login.Equals(login)
               && user.Senha.Equals(senha));
            }
        }
    }
}