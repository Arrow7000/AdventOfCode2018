// https://adventofcode.com/2018/day/3

module Day3

open FSharp.Text.RegexProvider
open Utils

type Rect =
    { Id : int
      Left : int
      Top: int
      Width: int
      Height: int }

type RectRegex =
    Regex< @"^#(?<id>\d+) @ (?<left>\d+),(?<top>\d+): (?<width>\d+)x(?<height>\d+)$" >

let lines = getLines "Day3.txt"


let getRect line =
    let r = RectRegex().TypedMatch(line)
    { Id = int r.id.Value
      Left = int r.left.Value
      Top = int r.top.Value
      Width = int r.width.Value
      Height = int r.height.Value }


let getCoveredInches left top width height =
    let rows = List.init height (fun i -> top + i)

    rows
    |> List.map (fun row -> List.init width (fun j -> (row, j + left)))
    |> List.collect id


let getClaims rects =
    let rec computer coveredInchesCounts remainingRects =
        match remainingRects with
        | [] ->
            coveredInchesCounts
            |> Map.filter (fun _ v -> v >= 2)
            |> Map.count
        | rect :: rest ->
            let coveredInches =
                getCoveredInches rect.Left rect.Top rect.Width rect.Height
            
            let newCoveredInchesCounts =
                coveredInches
                |> List.fold (fun map inch -> 
                                    match Map.tryFind inch map with
                                    | Some count -> Map.add inch (count+1) map
                                    | None -> Map.add inch 1 map) coveredInchesCounts

            computer newCoveredInchesCounts rest

    computer Map.empty rects


let part1 =
    lines
    |> List.map getRect
    |> getClaims