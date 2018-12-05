// Learn more about F# at http://fsharp.org

open System

let applyTrip f (a,b,c) = f a b c

let printForDay dayNum partNum result =
    printfn "Day %i part %i result is: %A" dayNum partNum result

[<EntryPoint>]
let main _ =
    [ 1, 1, Day1.part1
      1, 2, Day1.part2 ]
    |> List.iter (applyTrip printForDay)
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
