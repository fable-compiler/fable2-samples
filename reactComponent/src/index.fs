module ReactComponent

open Fable.React

type Props = 
    abstract member name : string option

type StandardComponent(props) as self=
    inherit PureComponent<Props,unit>(props) with
    do self.setInitState()
    override __.render() =
        let name = defaultArg props.name "nobody"
        div [] [str (sprintf "Hello %s" name)]

let FunctionComponent (props:Props) =
    let name = defaultArg props.name "nobody"
    div [] [str (sprintf "Hello %s" name)]

