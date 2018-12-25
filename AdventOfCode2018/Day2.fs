// https://adventofcode.com/2018/day/2

module Day2

open Utils

let lines = getLines "Day2.txt"

let getCounts (string  : string) =
    let folder stateMap char =
        let value =
            match Map.tryFind char stateMap with
            | Some count -> count + 1
            | None -> 1

        Map.add char value stateMap

    let countsMap =
        string
        |> Seq.fold folder Map.empty

    let getOccurences num = Map.filter (fun _ count -> count = num) >> Map.count
    let twos = getOccurences 2 countsMap
    let threes = getOccurences 3 countsMap

    (twos > 0, threes > 0)

let oneIfTrue = function
                | true -> 1
                | false -> 0

let multiplyBools (list : (bool * bool) list) =
    list
    |> List.fold (fun (count2,count3) (hasTwos,hasThrees) -> count2 + oneIfTrue hasTwos, count3 + oneIfTrue hasThrees) (0,0)

let part1 =
    lines
    |> List.map getCounts
    |> multiplyBools
    |> fun (a,b) -> a * b



type GappedStrings = (string * string) list

let getGappedStrings (str : string) : GappedStrings =
    [0..str.Length - 1]
    |> List.map (fun i -> str.Substring(0, i), str.Substring(i+1))

let exactlyOneInCommon listA listB =
    let intersect = Set.intersect (Set.ofList listA) (Set.ofList listB)
    match Set.toList intersect with
    | [ item ] -> Some item
    | _ -> None


let part2 =
    lines
    |> List.allPairs lines
    |> List.filter (fun (a,b) -> not (a = b)) // Strip pairs of same string
    |> List.distinctBy (fun (a,b) -> List.sort [a;b] |> List.reduce (+)) // Strip identical pairs in reverse different order
    |> List.choose (fun (a,b) -> exactlyOneInCommon (getGappedStrings a) (getGappedStrings b)) // Get pairs that have exactly one gapped string in common
    |> List.map (fun (a,b) -> a + b) // Concat gapped strings
    |> List.exactlyOne // Assert only one item is left