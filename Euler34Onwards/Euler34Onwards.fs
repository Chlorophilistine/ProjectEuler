namespace Euler34Onwards

type Euler34Onwards() = 
    member this.X = "F#"

open System.Collections.Generic

module ThirtyFour =

    let naturalNumbers =
        Seq.initInfinite (fun i -> i+1)

    let factorialGenerator n =
        if(n = 0) then 1 else seq {1..n} |> Seq.reduce (fun acc next -> acc * next)

    let factorials = new Dictionary<int, int>(9)
    let populate = [0..9] |> List.iter (fun n -> factorials.Add(n, (factorialGenerator n)))

    let factorial n = factorials.[n]

    let sumOfDigitFactorials x =
        let sX = x.ToString()
        sX |> Seq.map (fun n -> factorial(int32(n.ToString())))
        |> Seq.sum

    let findFactorialWithGreaterThanNDigits n =
        naturalNumbers
        |> Seq.map (fun x -> (x, (factorialGenerator x)))
        |> Seq.find (fun f -> snd(f).ToString() |> Seq.length > n)
        |> fst

    let digitsIn n =
        n.ToString() |> Seq.length

    let maxSumOfNDigits (n : int) =
        bigint(n) * bigint(factorial 9)
    
    let smallestNDigitNumber n =
        pown 10I (n - 1)

    let maxDigits =
        naturalNumbers
        |> Seq.find (fun n -> digitsIn (maxSumOfNDigits n) < n)

    let answer34 =
        seq{3I..smallestNDigitNumber(maxDigits)}
        |> Seq.where (fun n -> n = bigint(sumOfDigitFactorials n))
        |> Seq.sum
