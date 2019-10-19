﻿//-----------------------------------------------------------------------
// <copyright file="Usuario.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}