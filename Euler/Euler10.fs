open System

let factorsOf (x: int64) =
    let upperBound = int64(Math.Sqrt(double(x)))
    [2L..upperBound]
    |> Seq.where (fun i -> x % i = 0L)

let isPrime x =
    (x > 1L) && (factorsOf x |> Seq.length) = 0

let answer10 =
    {1L .. 1999999L}
    |> Seq.where isPrime
    |> Seq.sum