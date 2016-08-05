open System

let fibonacci =
    Seq.unfold (fun(current, next) -> Some(current, (next, current + next))) (1I, 1I)

let answer25 =
    (fibonacci 
    |> Seq.findIndex (fun fib -> fib.ToString() |> Seq.length = 1000) ) + 1
