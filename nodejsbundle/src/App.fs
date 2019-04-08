module App

open Fable.Core.JsInterop
open Fable.Import
open Fetch

importSideEffects "isomorphic-fetch"

// we get a json from our fetch request with a url field
// so we create this type to map the json object
type PictureInfo = { Url : string }

// This function will fetch a random dog url every reload of the page
let getRandomDogImage url =
    fetch url [] // use the fetch api to load our resource
    |> Promise.bind (fun res -> res.text()) // get the resul
    |> Promise.map (fun txt -> // bind the result to make further operation
      printfn "Result: %s" txt
      )

// start our app!
getRandomDogImage "https://random.dog/woof.json" |> ignore

