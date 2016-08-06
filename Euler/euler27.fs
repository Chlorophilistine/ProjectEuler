open System

let factorsOf x =
    let upperBound = int(Math.Sqrt(double(x)))
    [2..upperBound]
    |> Seq.where (fun i -> x % i = 0)

let isPrime x =
    (x > 1) && (factorsOf x |> Seq.length) = 0

let a = seq {-999..999}

let b = seq {-1000..1000}

let primeFormula a b =
    fun n -> n*n + a*n + b

let primeFormulasAndCoefficients =
    a |> Seq.collect (fun ac -> b |> Seq.map (fun bc -> ((ac, bc), primeFormula ac bc)))

let generateSequence ((x, y), frm) =
    let length =
        Seq.unfold (fun state -> if (frm(state) |> isPrime) then Some(state, state + 1) else None) 0
        |> Seq.length
    ((x, y), length)

let sequences =
    primeFormulasAndCoefficients
    |> Seq.map generateSequence

let maxSeq =
    sequences |> Seq.maxBy (fun ((x, y), length) -> length)

let answer27 =
    fst(fst(maxSeq)) * snd(fst(maxSeq))