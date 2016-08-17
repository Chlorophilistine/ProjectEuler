open System
open System.Numerics

let sumOfFifth x =
    x.ToString()
    |> Seq.map (fun i -> bigint.Parse(i.ToString()))
    |> Seq.map (fun i -> pown i 5)
    |> Seq.sum

let thing = sumOfFifth 112

let isSumFifth x =
    x = sumOfFifth x

let maxSum (numberDigits: int) pow =
    bigint(numberDigits) * (pown 9I pow)

let numDigitsToCheck pow =
    let n =
        Seq.unfold (fun state -> Some(state, (state + 1))) 1
        |> Seq.where (fun i -> (maxSum i pow).ToString().ToCharArray().Length < i)
        |> Seq.head
    n - 1

let biggestNumberOfNDigits n =
    seq{1..n} |> Seq.map (fun x -> 9I * pown 10I (x - 1)) |> Seq.sum

let answer30 =
    let upperBound = biggestNumberOfNDigits (numDigitsToCheck 5)
    seq{2I..upperBound} 
    |> Seq.where (fun i -> isSumFifth i)
    |> Seq.sum