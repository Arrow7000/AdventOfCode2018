// Learn more about F# at http://fsharp.org

open System


let printForDay dayNum result = printfn "Day %i result is: %A" dayNum result

[<EntryPoint>]
let main _ =
    [ 1, Day1.part1 ]
    |> List.iter (fun (day,result) -> printForDay day result)
    

    0 // return an integer exit code
