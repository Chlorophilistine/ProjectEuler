let factorial n =
    Seq.unfold (fun state -> if(state = 1I) then None else Some(state, state - 1I)) n
    |> Seq.fold (fun acc next -> acc * next) 1I


let answer20 =
    (factorial 100I).ToString()
    |> Seq.map (fun c -> int(c.ToString()))
    |> Seq.sum