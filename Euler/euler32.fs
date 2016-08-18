open System

let range = seq{1000L..9999L}

let pandigitalSequence = seq {1..9}

let comparison a b =
    if(a = b) then 0
    else if(a < b) then -1
    else 1

let isPandigital (product: int64) (multiplicand: int64) (multiplier: int64) =
    let joined = product.ToString() + multiplicand.ToString() + multiplier.ToString()
    let areIdentical = 
        joined
        |> Seq.map (fun ch -> int32(ch.ToString()))
        |> Seq.sort
        |> Seq.compareWith comparison pandigitalSequence
    areIdentical = 0

let pandigital (x: int64) =
    let upperBound = int64(Math.Sqrt(double(x)))
    seq{1L..upperBound}
    |> Seq.choose (fun i -> if(x % i = 0L) then Some(i, x/i) else None)
    |> Seq.choose (fun (m,n) -> if(isPandigital x m n) then Some(x) else None)


let answer32 =
    range
    |> Seq.choose (fun y -> pandigital y |> Seq.tryHead)
    |> Seq.sum
