﻿module FService
open MongoDB.Driver

open Models


let ListAllJemaat  =
    Models.Collections.JemaatCollection().Find(fun _ -> true ).ToEnumerable<Jemaat>

let CollJemaat = Collections.JemaatCollection()

let DeleteJemaat (jemaatDiKill) = 
    CollJemaat.DeleteOne(fun a -> a = jemaatDiKill)

let editJemaat (jemaatEdit : Jemaat) =
    let filter = Builders<Jemaat>.Filter.Eq((fun x -> x.Id), jemaatEdit.Id)
    CollJemaat.FindOneAndReplace(filter, jemaatEdit)

let GetRefMasterItems (Code : string) =
    Collections.RefMasterCollection().Find(fun a -> a.RefMasterCode = Code).First

