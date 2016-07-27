open System
open System.IO

let data =
    File.ReadAllLines(@"euler11.txt")
    |> Seq.map (fun line -> line.Split(' ') |> Seq.map int32 |> Seq.toArray)
    |> Seq.toArray

let Data2d =
    Array2D.init 20 20 (fun i j -> data.[i].[j])
