open System.Numerics

let answer16 =
    2I ** 1000
    |> string
    |> Seq.map (fun c -> int(c.ToString()))
    |> Seq.sum
