module ReactComponent

open Fable.React
open Fable.Core.JsInterop

// FunctionComponent.Of is intended to be used from F#
// To expose it in JS we need a slightly modified variant
// (We should likely add it to the Fable.React library)
type FunctionComponent with
    static member ForJS
                (render: 'Props->ReactElement,
                 ?displayName: string,
                 ?memoizeWith: 'Props -> 'Props -> bool)
                : ReactElementType<'Props> =
        match memoizeWith with
        | Some areEqual ->
            let memoElement = ReactBindings.React.memo(render, areEqual)
            match displayName with
            | Some name -> memoElement?displayName <- "Memo(" + name + ")"
            | None -> ()
            memoElement
        | None -> unbox render

// End of boilerplate! Let's start defining our component

// Since the props object is created from Javascript it's best to be defensive (use options) for the top level attributes.
// If you used a string it might work but there is no check to make sure the caller provided a value.
type Props = 
    abstract member name : string option

// A standard react component dervies from either Fable.React.Component or PureComponent.
// This is the most verbose way to define a component but also the most flexible.
type StandardComponent(props) as self=
    inherit PureComponent<Props,unit>(props) with
    do self.setInitState()
    override __.render() =
        let name = defaultArg props.name "nobody"
        div [] [str (sprintf "Hello %s" name)]

// If you expect the component to be consumed from javascript with JSX you can expose a bare function as a react component and that will work (including hooks).
// If you call this from F# it would act as a plain function so you would have to wrap it with FunctionComponent.Of (or `ofFunction`) if you need hooks to work. 
// see: https://fable.io/blog/Announcing-Fable-React-5.html
let FunComponent (props:Props) =
    let name = defaultArg props.name "nobody"
    div [] [str (sprintf "Hello %s" name)]

// Using FunctionComponent.ForJS we can add additional behaviour like memoization or a custom display name
let Fable5FunComponent =
    FunctionComponent.ForJS<Props>
        (FunComponent,
         memoizeWith = equalsButFunctions,
         displayName = "FableComponent")
