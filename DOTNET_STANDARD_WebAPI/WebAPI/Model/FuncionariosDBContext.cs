//-----------------------------------------------------------------------
// <copyright file="FuncionariosDBContext.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using System.Data.Entity;

namespace WebAPI.Models
{
    public class FuncionariosDBContext : DbContext
    {
        public FuncionariosDBContext() : base("name=FuncionariosDBContext")
        {
            Database.SetInitializer(new DBSeed());
        }

        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}