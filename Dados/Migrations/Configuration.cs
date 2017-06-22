namespace Dados.Migrations
{
    using Negocio.Dominio;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dados.SocialWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(Dados.SocialWebContext context)
        {
            /*context.Perfils.AddOrUpdate(
                p => p.NomeExibicao,
                new Perfil { NomeExibicao = "Felipe Neto", FotoPerfil = "https://noticias.gospelmais.com.br/files/2016/05/felipe-neto.jpg", UserID = "0101" },
                new Perfil { NomeExibicao = "Mark Zuckerberg", FotoPerfil = "https://images.forbes.com/media/lists/people/mark-zuckerberg_400x400.jpg", UserID = "0102" },
                new Perfil { NomeExibicao = "Ezeq Bolado", FotoPerfil = "https://media.licdn.com/mpr/mpr/shrinknp_200_200/p/4/005/07b/307/3965ace.jpg", UserID = "0103" },
                new Perfil { NomeExibicao = "Gustavo Escovedo", FotoPerfil = "https://avatars1.githubusercontent.com/u/16867459?v=3&s=460", UserID = "0104" },
                new Perfil { NomeExibicao = "Leonardo Cabelo", FotoPerfil = "https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAKSAAAAJGQ4MGVhYjQ2LWU5YTMtNDViYy1hNTEyLTdiMzY1ZmE4OWI0OA.jpg", UserID = "0105" }
            );

            Perfil perfil1 = context.Perfils.Where(x => x.UserID == "0101").FirstOrDefault();
            Perfil perfil2 = context.Perfils.Where(x => x.UserID == "0102").FirstOrDefault();
            Perfil perfil3 = context.Perfils.Where(x => x.UserID == "0103").FirstOrDefault();
            Perfil perfil4 = context.Perfils.Where(x => x.UserID == "0104").FirstOrDefault();
            Perfil perfil5 = context.Perfils.Where(x => x.UserID == "0105").FirstOrDefault();

            context.Postagems.AddOrUpdate(
                p => p.PerfilId,
                new Postagem {PerfilId = perfil1.id, UserId = "0101", TextoPostagem = "blá blá blá não faz sentido", DataPostagem = DateTime.Now.AddDays(-1) },
                new Postagem { PerfilId = perfil2.id, UserId = "0102", TextoPostagem = "I like Horto Home ;)", DataPostagem = DateTime.Now.AddHours(2) },
                new Postagem { PerfilId = perfil3.id, UserId = "0103", TextoPostagem = "São dois tipos de problema...", DataPostagem = DateTime.Now.AddDays(-4).AddMinutes(30) },
                new Postagem { PerfilId = perfil4.id, UserId = "0104", TextoPostagem = "Se usar-mos a busca binária, acharemos a chave da sala em menos tempo. Ah eu não peguei ela...", DataPostagem = DateTime.Now.AddDays(-4) },
                new Postagem { PerfilId = perfil5.id, UserId = "0105", TextoPostagem = "Não falei que dava? Só montar um Frankensteinzinho cara", DataPostagem = DateTime.Now.AddDays(-2) },
                new Postagem { PerfilId = perfil4.id, UserId = "0104", TextoPostagem = "Terminei em menos tempo e há mais tempo... #ficaadica", DataPostagem = DateTime.Now.AddDays(-4).AddMinutes(20) },
                new Postagem { PerfilId = perfil4.id, UserId = "0104", TextoPostagem = "Isso pra mim é HTML", DataPostagem = DateTime.Now.AddDays(-4).AddMinutes(40) }
            );*/
        }
    }
}
