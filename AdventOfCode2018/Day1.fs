// https://adventofcode.com/2018/day/1

module Day1

open Commons

let changes =
    getLines "Day1.txt"
    |> List.map int

let part1 =
    changes
    |> List.fold (+) 0

let rotate list =
    match list with
    | [] -> []
    | first :: rest -> rest @ [ first ]

let part2 =
    let rec recurser set sum list =
        let first = List.head list
        let newSum = sum + first
        match Set.contains newSum set with
        | true -> newSum
        | false ->
            let rotated = rotate list
            let newSet = Set.add newSum set
            recurser newSet newSum rotated

    recurser Set.empty 0 changes