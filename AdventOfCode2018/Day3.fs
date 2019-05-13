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

let rects =
    lines
    |> List.map getRect

let part1 = getClaims rects



let intersect (rect1 : Rect) (rect2 : Rect) =
    let areVerticallyDisparate =
        rect1.Top > rect2.Top + rect2.Height || rect1.Top + rect1.Height < rect2.Top

    let areHorizonDisparate =
        rect1.Left + rect1.Width < rect2.Left || rect1.Left > rect2.Left + rect2.Width

    let theyDoIntersect = not (areVerticallyDisparate || areHorizonDisparate)
    theyDoIntersect



let getNonOverlappingClaimId rects =
    let rec eliminate rectSet rects =
        match rects with
        | [] ->
            rectSet
            |> Set.toList
            |> List.exactlyOne
            |> fun rect -> rect.Id
        | rect :: rest ->
            let newSet =
                rectSet
                |> Set.filter (fun setRect -> setRect.Id = rect.Id || not (intersect setRect rect))
            eliminate newSet rest

    eliminate (Set.ofList rects) rects

let part2 = getNonOverlappingClaimId rects
