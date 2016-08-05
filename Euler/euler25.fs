open System

let fibonacci =
    Seq.unfold (fun(current, next) -> Some(current, (next, current + next))) (1I, 1I)

let countFrom1 =
    Seq.initInfinite (fun index -> index + 1)

let answer25 =
    fibonacci 
    |> Seq.map2 (fun index fib -> (index, fib)) countFrom1
    |> Seq.where (fun (index, fib) -> fib.ToString() |> Seq.length = 1000)
    |> Seq.head
    |> fst
