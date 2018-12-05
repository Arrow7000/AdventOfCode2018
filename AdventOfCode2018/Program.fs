// Learn more about F# at http://fsharp.org

open System


let printForDay dayNum partNum result =
    printfn "Day %i part %i result is: %A" dayNum partNum result

[<EntryPoint>]
let main _ =
    [ 1, 1, Day1.part1
      1, 2, Day1.part2 ]
    |> List.iter (fun (day, part, result) -> printForDay day part result)
    
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
