using Microsoft.EntityFrameworkCore;
using ConectaCafe.Models;

namespace CozaStore.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular Categorias
        List<Categoria> categorias = new() {
            new() {
                Id = 1,
                Nome = "Cafés Quentes",
            },
            new() {
                Id = 2,
                Nome = "Cafés Gelados",
            },
            new() {
                Id = 3,
                Nome = "Bebidas Refrescantes",
            },
            new() {
                Id = 4,
                Nome = "Salgados",
            },
            new() {
                Id = 5,
                Nome = "Doces",
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region Popular Produtos
        List<Produto> produtos = new() {
            new() {
                Id = 1,
                Nome = "Vanilla",
                CategoriaId = 1,
                Preco = 15,
                Foto = "\\img\\produtos\\1.png"
            },
            new() {
                Id = 2,
                Nome = "Cappucino Italiano",
                CategoriaId = 1,
                Preco = 10,
                Foto = "\\img\\produtos\\2.png"
            },
            new() {
                Id = 3,
                Nome = "Mocha",
                CategoriaId = 1,
                Preco = 12,
                Foto = "\\img\\produtos\\3.png"
            },
        };
        builder.Entity<Produto>().HasData(produtos);
        #endregion

        #region Popular Tags
        List<Tag> tags = new() {
            new() {
                Id = 1,
                Nome = "Café",
            },
            new() {
                Id = 2,
                Nome = "Estilo de Vida",
            },
            new() {
                Id = 3,
                Nome = "Relaxar",
            }
        };
        builder.Entity<Tag>().HasData(tags);
        #endregion

    }
}