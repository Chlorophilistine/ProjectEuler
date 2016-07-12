// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open System.Linq
open System.IO

let naturalNumbers =
    Seq.initInfinite (fun index -> index)
    |> Seq.skip 1

let answer1 =
    naturalNumbers
    |> Seq.take 999
    |> Seq.where (fun i -> i % 3 = 0 || i % 5 = 0)
    |> Seq.sum

let fibonacci =
    Seq.unfold (fun(current, next) -> Some(current, (next, current + next))) (0, 1)

let answer2 =
    fibonacci
    |> Seq.takeWhile (fun value -> value <= 4000000)
    |> Seq.where (fun value -> value % 2 = 0)
    |> Seq.sum

let factorsOf (x: int64) =
    let upperBound = int64(Math.Sqrt(double(x)))
    [2L..upperBound]
    |> Seq.where (fun i -> x % i = 0L)

let isPrime x =
    (x > 1L) && (factorsOf x |> Seq.length) = 0

let answer3 =
    factorsOf 600851475143L
    |> Seq.where isPrime
    |> Seq.max


let isPalindromicNumber (x: int32) =
    let chars = x.ToString().ToCharArray()
    let revChars = Array.rev chars
    chars.SequenceEqual(revChars)

let numbers = [100..999]

let products = numbers |> Seq.collect (fun i -> numbers |> Seq.map (fun j -> i * j))

let answer4 = products |> Seq.where isPalindromicNumber |> Seq.max

let factors = [1..20]

let isDivisibleBy x y =
    (x % y) = 0

let isDivisibleByAll n numbers =
    numbers |> Seq.forall (fun i -> isDivisibleBy n i)

let answer5 =
    naturalNumbers
    |> Seq.skip 19
    |> Seq.where (fun i -> isDivisibleByAll i factors)
    |> Seq.head


let numbersFor6 =
    naturalNumbers
    |> Seq.take 100

let answer6 =
    (numbersFor6 |> Seq.sum |> (fun n -> n * n)) - (numbersFor6 |> Seq.map (fun i -> i * i) |> Seq.sum)

let answer7 =
    naturalNumbers
        |> Seq.where (fun x -> isPrime(int64(x)))
        |> Seq.take 10001
        |> Seq.last

let answer8 = 
    File.ReadAllText(@"Euler\euler8.txt")
    |> Seq.map (fun c -> int32(c.ToString()))
    |> Seq.windowed 13
    |> Seq.map (fun ints -> ints |> Seq.fold (fun acc elem -> acc * int64(elem)) 1L)
    |> Seq.max     


[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code
