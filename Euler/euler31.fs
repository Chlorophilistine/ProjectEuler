// def count( n, m ):
//    if n < 0 or m <= 0: #m < 0 for zero indexed programming languages
//        return 0
//    if n == 0: # needs be checked after n & m, as if n = 0 and m < 0 then it would return 1, which should not be the case.
//       return 1
// 
//    return count( n, m - 1 ) + count( n - S[m], m )


let total = 200

let coins = [1; 2; 5; 10; 20; 50; 100; 200]

let rec count n m =
    if(n < 0 || m <= 0) then 0
    else if( n = 0) then 1
    else (count n (m - 1)) + (count (n - coins.[(m-1)]) m)

let answer31 = count 200 coins.Length