open System
open System.Numerics

let a = seq {2..100}

let formula a b = BigInteger.Pow(a, b)

let combinations =
    a
    |> Seq.map (fun x -> bigint(x))
    |> Seq.collect (fun av -> a |> Seq.map (fun bv -> formula av bv))
    |> Seq.sort
    |> Seq.distinct
    |> Seq.length
