open System
open System.IO

let scoreString name =
    name
    |> Seq.map (fun c -> int(c) - 64)
    |> Seq.sum

let names =
    File.ReadAllLines("p022_names.txt")
    |> Seq.map (fun s -> s.Replace("\"", ""))
    |> Seq.collect (fun s -> s.Trim().Split(','))
    |> Seq.map (fun s -> s.ToUpper())
    |> Seq.sort

let scores =
    names |> Seq.map scoreString

let position =
    seq{1..Seq.length scores}

let answer22 =
    Seq.map2 (fun pos score -> pos * score) position scores
    |> Seq.sum


