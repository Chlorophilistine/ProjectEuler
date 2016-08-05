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
    |> Seq.toArray

let an = abundantNumbers

let isSumAbundant n =
    let pairs = Seq.collect (fun item -> Seq.map (fun x -> (item, x)) an) an
    pairs |> Seq.exists (fun (a,b) -> a + b = n)


let notAbundant =
    naturalNumbers
    |> Seq.take 28122
    |> Seq.skip 10
    |> Seq.map int32
    |> Seq.where (fun x -> isSumAbundant x = false)

let answer32 = notAbundant |> Seq.sum