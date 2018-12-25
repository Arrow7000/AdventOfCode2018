// Learn more about F# at http://fsharp.org

open System

let applyTriple f (a,b,c) = f a b c

let printForDay dayNum partNum result =
    printfn "Day %i part %i result is: %A" dayNum partNum result

[<EntryPoint>]
let main _ =
    [ [ 1, 1, string Day1.part1
        1, 2, string Day1.part2 ]
      [ 2, 1, string Day2.part1
        2, 2, Day2.part2 ] ]
    |> List.collect id
    |> List.iter (applyTriple printForDay)
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
