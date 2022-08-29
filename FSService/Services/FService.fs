module FService
open MongoDB.Driver
open MongoDB.Bson
open Models
open System
open System.Text

let ListAllJemaat  =
    Models.Collections.JemaatCollection().Find(fun _ -> true ).ToEnumerable<Jemaat>

let CollJemaat = Collections.JemaatCollection()

let CollJadwal = Collections.JadwalCollection()

let DeleteJemaat (jemaatDiKill) = 
    CollJemaat.DeleteOne(fun a -> a = jemaatDiKill)

let editJemaat (jemaatEdit : Jemaat) =
    let filter = Builders<Jemaat>.Filter.Eq((fun x -> x.Id), jemaatEdit.Id)
    CollJemaat.FindOneAndReplace(filter, jemaatEdit)

let ListAllJemaatJson  =
    Models.Collections.JemaatCollection().Find(fun _ -> true ).ToEnumerable<Jemaat>().ToJson()

let GetRefMasterItems (Code : string) =
    Collections.RefMasterCollection().Find(fun a -> a.RefMasterCode = Code).First
