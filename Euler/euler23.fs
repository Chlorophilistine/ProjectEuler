open System

let naturalNumbers =
    Seq.unfold (fun state -> Some(state, state + 1L)) 1L

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
    |> Seq.map int32
    |> Seq.where isAbundant

let isSumAbundant n =
    let pairs = Seq.collect (fun item -> Seq.map (fun x -> (item, x)) abundantNumbers) abundantNumbers
    pairs |> Seq.exists (fun (a,b) -> a + b = n)

let abundantSums =
    abundantNumbers
    |> Seq.collect (fun x -> Seq.map( fun y -> x + y) abundantNumbers)
    |> Seq.where (fun sum -> sum <= 21823)
    |> Seq.distinct

let answer23 =
    (seq {1..28123} |> Seq.sum) - (abundantSums |> Seq.sum)
