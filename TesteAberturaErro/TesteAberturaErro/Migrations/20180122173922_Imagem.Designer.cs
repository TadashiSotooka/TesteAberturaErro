﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TesteAberturaErro.Models;

namespace TesteAberturaErro.Migrations
{
    [DbContext(typeof(TesteAberturaErroContext))]
    [Migration("20180122173922_Imagem")]
    partial class Imagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteAberturaErro.Models.Erros", b =>
                {
                    b.Property<int>("IdErro")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao");

                    b.Property<string>("Email");

                    b.Property<string>("Imagem");

                    b.Property<string>("Produto");

                    b.Property<string>("Severidade");

                    b.Property<string>("Titulo");

                    b.HasKey("IdErro");

                    b.ToTable("Erros");
                });
#pragma warning restore 612, 618
        }
    }
}
