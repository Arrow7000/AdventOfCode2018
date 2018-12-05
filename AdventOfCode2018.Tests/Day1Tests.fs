module Day1Tests

open Xunit
open Swensen.Unquote

open Day1

[<Fact>]
let ``part 1 solution`` () =
    test <@ part1 = 508 @>

[<Fact>]
let ``part 2 solution`` () =
    test <@ part2 = 549 @>
