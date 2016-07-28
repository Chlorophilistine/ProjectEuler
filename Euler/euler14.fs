open System

let nextCollatz n =
    match n with
    | var1 when var1 % 2L = 0L -> n/2L
    | _ -> (3L * n) + 1L

let collatz seed =
    Seq.unfold (fun state -> if(state = 1L) then None else Some(state, nextCollatz state)) seed


let naturalNumbers =
    Seq.unfold (fun state -> Some(state, state + 1L)) 1L


let answer14 =
    naturalNumbers
    |> Seq.take 999999
    |> Seq.map (fun seed -> (seed, collatz seed |> Seq.length))
    |> Seq.maxBy (fun tpl -> snd(tpl))
