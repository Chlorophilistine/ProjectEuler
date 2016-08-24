namespace Euler34Onwards

type Euler34Onwards() = 
    member this.X = "F#"

open System
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

module ThirtyFive =
    
    let factorsOf (x: int64) =
        let upperBound = int64(Math.Sqrt(double(x)))
        [2L..upperBound]
        |> Seq.where (fun i -> x % i = 0L)

    let isPrime x =
        (x > 1L) && (factorsOf x |> Seq.isEmpty)

    let permutations (x: int32) =
        let xStr = x.ToString() |> Seq.toList
        let numPermutations = (xStr |> Seq.length) - 1
        [0..numPermutations]
        |> List.map (fun p -> List.permute (fun index -> (index + p) % (numPermutations + 1)) xStr)
        |> List.map (fun s -> String.Join("", s |> List.toArray))
        |> List.map int32
        |> List.filter (fun s -> s.ToString().Length = xStr.Length)

    let answer35 =
        let n =
            seq {100..999999}
            |> Seq.where (int64 >> isPrime)
            |> Seq.where (fun x -> x |> permutations |> (fun m -> not (Seq.isEmpty m) && (Seq.forall (int64 >> isPrime) m)))
            |> Seq.length
        n + 13

module ThirtySix =

    let inBinary (x: int) = Convert.ToString(x, 2) 

    let isPalindromicInBase10AndBase2 n =
        let palindromicInBase10 = String.Join("", (n.ToString() |> Seq.toArray |> Array.rev)) = n.ToString()
        let inBase2 = inBinary n
        let palindromicInBase2 = String.Join("", (inBase2 |> Seq.toArray |> Array.rev)) = inBase2
        palindromicInBase10 && palindromicInBase2

    let answer36 =
        [1..999999]
        |> Seq.where isPalindromicInBase10AndBase2
        |> Seq.sum

module ThirtySeven =

    let factorsOf (x: int64) =
        let upperBound = int64(Math.Sqrt(double(x)))
        [2L..upperBound]
        |> Seq.where (fun i -> x % i = 0L)

    let isPrime x =
        (x > 1L) && (factorsOf x |> Seq.isEmpty)

    let naturalNumbers = Seq.unfold (fun state -> Some(state, state + 1L)) 1L

    let sequenceOfTruncatedNumbers (x: int64) truncator =
        let sX = x.ToString() |> Seq.toList
        sX |> Seq.unfold (fun state -> if(state |> Seq.isEmpty) then None else Some(new String(state |> List.toArray) |> int64, (truncator state)))

    let generateTruncatedSequence (x: int64) =
        Seq.append (sequenceOfTruncatedNumbers x List.tail) (sequenceOfTruncatedNumbers x (List.rev >> List.tail >> List.rev))
        |> Seq.distinct

    let answer37 =
        naturalNumbers
        |> Seq.skip 8
        |> Seq.where isPrime
        |> Seq.map (fun i -> (i, generateTruncatedSequence i))
        |> Seq.where (fun (p, ps) -> Seq.forall isPrime ps)
        |> Seq.take 11
        |> Seq.sumBy (fun (p, ps) -> p)
