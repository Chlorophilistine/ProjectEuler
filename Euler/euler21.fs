open System

let divisors n =
    let upperLimit = n/2 + 1
    seq {1..upperLimit}
    |> Seq.where (fun x -> n % x = 0)

let d n =
    divisors n
    |> Seq.sum


let amicablePair x =
    let sumdx = d x
    let dsumdx = d sumdx
    if(dsumdx = x && x <> sumdx) then Some(x, sumdx) else None

let sumAmicableNumbers =
    seq {0..9999}
    |> Seq.map (fun x -> amicablePair x)
    |> Seq.choose id
    |> Seq.map (fun opt -> snd(opt) + fst(opt))
    |> Seq.sum
    
let answer21 = sumAmicableNumbers / 2