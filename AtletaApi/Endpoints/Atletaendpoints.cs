using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using AtletaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace AtletaApi.Endpoints
{
    public static class AtletaEndpoints
    {
        private static readonly List<Atleta> objetos = new List<Atleta>();

        public static void AdicionarAtletaEndpoints(this WebApplication app)
        {
            app.MapGet("/atletas", Get);
            app.MapGet("/atletas/{id}", GetById);
            app.MapPost("/atletas", Post);
            app.MapPut("/atletas/{id}", Put);
            app.MapDelete("/atletas/{id}", Delete);
        }

        private static IResult Get()
        {
            return objetos.Any() ? Results.Ok(objetos) : Results.NotFound();
        }

        private static IResult GetById(long id)
        {
            var obj = objetos.FirstOrDefault(x => x.Id == id);
            return obj != null ? Results.Ok(obj) : Results.NotFound();
        }

        private static IResult Post(Atleta obj)
        {
            obj.Id = (objetos.MaxBy(x => x.Id)?.Id ?? 0) + 1;
            objetos.Add(obj);
            return Results.Created($"/atletas/{obj.Id}", obj);
        }

        private static IResult Put(long id, Atleta objNovo)
        {
            if (id != objNovo.Id)
                return Results.BadRequest();

            var obj = objetos.FirstOrDefault(x => x.Id == id);
            if (obj == null)
                return Results.NotFound();

            obj.Nome = objNovo.Nome;
            obj.Altura = objNovo.Altura;

            return Results.NoContent();
        }

        private static IResult Delete(long id)
        {
            var obj = objetos.FirstOrDefault(x => x.Id == id);
            if (obj == null)
                return Results.NotFound();

            objetos.Remove(obj);
            return Results.NoContent();
        }
    }
}
