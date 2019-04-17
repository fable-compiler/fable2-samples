module Tests

open Fable.Core
open Fable.Core.JsInterop
open App

let inline equal (expected: 'T) (actual: 'T): unit =
    Testing.Assert.AreEqual(expected, actual)

let [<Global>] describe (name: string) (f: unit->unit) = jsNative
let [<Global>] it (msg: string) (f: unit->unit) = jsNative

describe "my tests" <| fun _ ->
    it "calls App.randomFeature() successfully" <| fun () ->
      randomFeature() |> Seq.sum = 6 |> equal true
