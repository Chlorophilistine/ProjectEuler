namespace Euler34Onwards

type Euler34Onwards() = 
    member this.X = "F#"

module ThirtyFour =

    let factorial n =
        Seq.unfold (fun state -> if(state = 1I) then None else Some(state, state - 1I)) n
        |> Seq.fold (fun acc next -> acc * next) 1I

    let sumOfDigitFactorials x =
        let sX = x.ToString()
        sX |> Seq.map (fun n -> factorial(bigint.Parse(n.ToString())))
        |> Seq.sum