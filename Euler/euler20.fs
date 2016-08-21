let factorial n =
    if(n = 0I) then 1I else seq {1I..n} |> Seq.reduce (fun acc next -> acc * next)


let answer20 =
    (factorial 100I).ToString()
    |> Seq.map (fun c -> int(c.ToString()))
    |> Seq.sum