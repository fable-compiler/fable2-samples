module App

open Fable.Core.JsInterop
open Fable.Import
open Fable.Core

(*
  First way to interop with our javascript:
  Create an interface listing all exported functions and members
  Function name must be the same as the one written in the .js file
*)
module Alert = 
  type IAlert = 
    abstract triggerAlert : message:string -> unit // takes a string parameter and does not return anything
    abstract someString: string

  // import our lib using ES6 imports.
  // The star just means we'll import everything that's exported
  // We map the import to our type IAlert in order to have an actual access point.
  [<Import("*", "../public/alert.js")>]
  let lib: IAlert = jsNative

Alert.lib.triggerAlert ("Hey I'm calling my js library from Fable > " + Alert.lib.someString)


(*
  Second way to interop with our javascript:
  Just create functions as placeholders for our exported members 
  Put these into a module just to make thing a little bit clearer
*)
module Canvas = 
  // here we just import a member function from canvas.js called drawSmiley. 
  let drawSmiley: id:string -> unit = importMember  "../public/canvas.js"
  let drawBubble: id:string -> unit = importMember  "../public/canvas.js"


Canvas.drawBubble "bubble"
Canvas.drawSmiley "smiley"

(*
  Third way to interop with a javascript: use a class
  We need a:
  1 - a description: an interface which will mimic our js MyClass class
  2 - a caller: a MyClassType to invoke a new MyClass
  3 - a glue: a myClassCallInstance that will act as the glue between our lib and MyClassCaller
*)
type MyClass = // 1
  abstract awesomeInteger: int with get, set
  
type MyClassCaller = // 2 
  [<Emit("new $0($1...)")>]
  abstract Create : awesomeInteger:int ->  MyClass //= jsNative  // takes a string parameter and does not return anything

[<Import("default", "../public/MyClass.js")>] // 3
let myClassCallInstance : MyClassCaller = jsNative

// let's make our object mutable to be able to change its members
let mutable myObject = myClassCallInstance.Create 40

// using getter
let whatDoIget = myObject.awesomeInteger // using getter
Alert.lib.triggerAlert ("Hey I'm calling my js class from Fable. It gives " + (string whatDoIget))

// using setter
myObject.awesomeInteger <- 42
Alert.lib.triggerAlert ("Now it's better. It gives " + (string myObject.awesomeInteger))
