open System

let naturalNumbers =
    Seq.unfold (fun state -> Some(state, state + 1)) 1

let divisors n =
    let upperLimit = n/2 + 1
    seq {1..upperLimit}
    |> Seq.where (fun x -> n % x = 0)

let isAbundant n =
    (divisors n |> Seq.sum) > n

let abundantNumbers =
    naturalNumbers
    |> Seq.take 28122
    |> Seq.skip 10
    |> Seq.where isAbundant

let abundantSums =
    abundantNumbers
    |> Seq.collect (fun x -> abundantNumbers |> Seq.map (fun y -> x + y))
    |> Seq.where (fun sum -> sum <= 21823)
    |> Seq.distinct
    |> Seq.toArray

let answer23 =
    (seq {1..28123} |> Seq.sum) - (abundantSums |> Seq.sum)
