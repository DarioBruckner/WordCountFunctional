open System
open System.IO


let input = File.ReadAllText("..\..\..\..\Text.txt")


let count (text : string) =
    let words = text.Split([|'.'; ' '; '\n'; '\r'; '*';'+';':'; '\"'; '('; ')';'['; ']'; '#'; ','; '-';';';'!';'?';':'; '\''; '\\'; '/'; '&'; '%'; '$'; '<';'>'; '`'; '^'; '@';'_';'='; '~';'{';'|';'}'|]) 
    (words)

let temp = count input

let output =
    temp
    |> Seq.sort 
    |> Seq.countBy id
    |> Seq.toList
    |> List.sortByDescending snd

for item in output do
    printfn "%A %A" (snd item) (fst item)


//for item in temp do 
//    printf "%A" temp