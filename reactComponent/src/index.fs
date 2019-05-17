module ReactComponent

open Fable.React

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
// If you call this from F# it would act as a plain function so you would have to wrap it with FunctionComponent.Of if you need hooks to work. 
// see: https://fable.io/blog/Announcing-Fable-React-5.html
let FunComponent (props:Props) =
    let name = defaultArg props.name "nobody"
    div [] [str (sprintf "Hello %s" name)]

// Using FunctionComponent.Of also works and gives you a consistent behavior if called from either Javascript or Fable
let Fable5FunComponent (props:Props) =
    FunctionComponent.Of(FunComponent, memoizeWith = equalsButFunctions) props
