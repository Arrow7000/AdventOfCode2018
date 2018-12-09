module SolutionTests

open Xunit
open Swensen.Unquote


[<Fact>]
let ``Day 1 part 1 solution`` () =
    test <@ Day1.part1 = 508 @>

[<Fact>]
let ``Day 1 part 2 solution`` () =
    test <@ Day1.part2 = 549 @>




[<Fact>]
let ``Day 2 part 1 solution`` () =
    test <@ Day2.part1 = 5904 @>
