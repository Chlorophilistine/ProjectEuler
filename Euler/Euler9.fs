open System

let triples =
    seq {
        for i = 1 to 1000 do
            for j = 1 to 1000 do
                for k = 1 to 1000 do
                    if i + j + k = 1000 && i < j && j < k then yield [i; j; k]
    }

let isPythagoreanTriple(triple : int list) =
    match triple with
    | [a; b; c] -> a*a + b*b = c*c
    | _ -> false

let triplet =
    triples |> Seq.where isPythagoreanTriple |> Seq.head

let answer9 = triplet |> Seq.fold (fun acc item -> acc * item) 1