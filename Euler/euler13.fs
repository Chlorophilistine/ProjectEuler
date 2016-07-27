open System
open System.IO
open System.Numerics

let sum = 
    let zero = BigInteger.Parse("0")
    File.ReadLines(@"Euler/euler13.txt")
    |> Seq.map (fun line -> BigInteger.Parse(line.Trim()))
    |> Seq.fold (fun acc next -> BigInteger.Add(acc, next)) zero

let answer13 =
    sum.ToString().Substring(0, 10)

