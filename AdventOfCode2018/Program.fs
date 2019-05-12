// Learn more about F# at http://fsharp.org

open System

let applyTriple f (a,b,c) = f a b c

let printForDay dayNum partNum result =
    printfn "Day %i part %i result is: %A" dayNum partNum result

let printResult dayNum part1 part2 =
    printForDay dayNum 1 part1
    printForDay dayNum 2 part2

let inline s x = string x

[<EntryPoint>]
let main _ =
    [ s Day1.part1, s Day1.part2
      s Day2.part1, s Day2.part2
      s Day3.part1, s "" ]
    |> List.iteri (fun i (a,b) -> printResult (i+1) a b)
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
