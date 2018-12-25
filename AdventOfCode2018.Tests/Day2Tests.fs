module Day2Tests

open Xunit
open Swensen.Unquote

open Day2

[<Fact>]
let ``Gapping strings works`` () =
    let result = getGappedStrings "abcde"
    let expected =
        [ "","bcde"
          "a","cde"
          "ab","de"
          "abc","e"
          "abcd","" ]

    test <@ result = expected @>