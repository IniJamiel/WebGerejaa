open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open MongoDB.Bson
open FService



[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    app.MapGet("/", Func<string>(fun () -> "Hello World!")) |> ignore
    app.MapGet("/ListAll", Func<String>(fun () -> ListAllJemaatJson)) |> ignore
    app.Run()

    0 // Exit code

