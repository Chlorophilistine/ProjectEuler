module Euler33 =

  open System

  let numerator = seq {10..99}
  let denominator = seq {10..99}

  let possibleFractions =
    numerator
    |> Seq.collect (fun num -> Seq.choose (fun den -> if(num < den) then Some(num, den) else None) denominator)

  let areEqualNotZero (a: char) (b: char) =
    a = b && a <> '0'

  let anyAreEqualNotZero (sNum: string) (sDen: string) =
    areEqualNotZero sNum.[0] sDen.[0] || areEqualNotZero sNum.[1] sDen.[0] || areEqualNotZero sNum.[0] sDen.[1] || areEqualNotZero sNum.[1] sDen.[1]

  let shareDigit(num, den) =
    let sNum = num.ToString()
    let sDen = den.ToString()
    anyAreEqualNotZero sNum sDen

  let areEqualWithoutSharedDigit(num, den) =
    let sNum = num.ToString()
    let sDen = den.ToString()
    let commonDigit = (Set.intersect (Set.ofSeq sNum) (Set.ofSeq sDen)).MinimumElement
    let newNum = int32((if( sNum.[0] = commonDigit) then sNum.[1] else sNum.[0]).ToString())
    let newDen = int32((if( sDen.[0] = commonDigit) then sDen.[1] else sDen.[0]).ToString())
    (newNum <> 0 || newDen <> 0) && ((double(num)/double(den)) = (double(newNum)/double(newDen)))

  let isCurious(num, den) =
    shareDigit(num, den) && areEqualWithoutSharedDigit(num, den)

  let curiousFractions =
    possibleFractions
    |> Seq.where isCurious

  let answer33 =
    curiousFractions
    |> Seq.fold (fun state next -> ((fst(state) * fst(next)), (snd(state) * snd(next)))) (1, 1)
