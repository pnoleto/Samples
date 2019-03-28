//-----------------------------------------------------------------------
// <copyright file="DBSeed.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI
{
    public class DBSeed : DropCreateDatabaseAlways<FuncionariosDBContext> {

        public override void InitializeDatabase(FuncionariosDBContext context)
        {
            context.Funcionarios.Add(new Funcionario() {
                FuncionarioId=1,
                Nome="Pedro",
                Sexo="M",
                Email="teste",
                Setor="TI",
                Salario= 4000
            });

            context.Usuarios.Add(new Usuario()
            {
                UsuarioId = 1,
                Nome = "teste",
                Senha = "teste",
                Login = "teste",
                Email = "teste"
            });

            base.Seed(context);
            base.InitializeDatabase(context);
        }
    }
}