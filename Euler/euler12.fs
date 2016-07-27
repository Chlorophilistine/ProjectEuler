open System

let factorsOf (x: int64) =
    let upperBound = int64(Math.Sqrt(double(x)))
    [2L..upperBound]
    |> Seq.where (fun i -> x % i = 0L)
    |> Seq.append [1L]
    |> Seq.collect (fun n -> [n; x/n])

let triangularNumbers =
    Seq.initInfinite (fun index -> seq {for i in 1 .. (index + 1) -> i} |> Seq.sum)

let answer12 =
    triangularNumbers
    |> Seq.where (fun tnum -> (int64(tnum) |> factorsOf |> Seq.length) > 500)
    |> Seq.head
