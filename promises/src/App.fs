module App

open Fable.Core.JsInterop
open Fable.Import
open Fetch
open Thoth.Json

// we get a json from our fetch request with a url field
// so we create this type to map the json object
type PictureInfo = { Url : string }

let window = Browser.Dom.window

// this simple function takes an url, creates an img element and add it to our myDogContainer div created in index.html
let showPic url =
  // make image mutable since we need to mutate it's src field
  let mutable image : Browser.Types.HTMLImageElement = unbox window.document.createElement "img"
  let container = window.document.getElementById "myDogContainer"
  image.src <- url
  image.width <- 200.
  container.appendChild image |> ignore // ignore means we don't need to use the return value. Since F# is a functional language we always do return something.

// This function will fetch a random dog url every reload of the page
let getRandomDogImage url =
    fetch url [] // use the fetch api to load our resource
    |> Promise.bind (fun res -> res.text()) // get the resul
    |> Promise.map (fun txt -> // bind the result to make further operation

      // Use Thoth, a F# library to decode the json message
      // the message will come as: {"url":"https://random.dog/580ce3c8-a8bf-48a8-92cc-68d1955c7dc8.jpg"}
      // We tell Thoth to decode this and map the Json to our PictureInfo type.
      let decoded = Decode.Auto.fromString<PictureInfo> (txt, caseStrategy = CamelCase)
      match decoded with
      | Ok catURL ->  // everything went well! great!
        let actualDogURL = catURL.Url
        printfn "Woof! Woof! %s" actualDogURL
        showPic actualDogURL
      | Error decodingError -> // oh the decoder encountered an error. The string that was sent back from our fetch request does not map well to our PictureInfo type.
        failwith (sprintf "was unable to decode: %s. Reason: %s" txt decodingError)
      )

// start our app!
getRandomDogImage "https://random.dog/woof.json" |> ignore
printfn "done!"


