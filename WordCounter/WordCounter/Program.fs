open System
open System.IO
open FSharp.Collections.ParallelSeq


let GetAllFiles(location : string, filetype : string) =
    try
        let ret = Directory.GetFiles(location, "*."+ filetype)
        (ret)
    with
        | :? System.IO.DirectoryNotFoundException -> printf "Directory not found"; (null)
   
let count (text : string) =
    let words = text.Split([|'.'; ' '; '\n'; '\r'; '*';'+';':'; '\"'; '('; ')';'['; ']'; '#'; ','; '-';';';'!';'?';':'; '\''; '\\'; '/'; '&'; '%'; '$'; '<';'>'; '`'; '^'; '@';'_';'='; '~';'{';'|';'}'|], StringSplitOptions.RemoveEmptyEntries) 
    (words)
   
let AddallFilesToString (files : string[]) =
    let mutable temp = ""
    let mutable listofStrings : string list = []
    for item in files do
        temp <- File.ReadAllText(item)
        listofStrings <- temp :: listofStrings
    let ret = String.concat " " listofStrings      
    (ret)

let userdirectory = System.Console.ReadLine();
let filetype = System.Console.ReadLine();

let temparr = string[]


let arr =  GetAllFiles (userdirectory, filetype)

if arr <> null then
    
    let input = AddallFilesToString arr

    let temp = count input

    let output =
        temp
        |> PSeq.sort
        |> PSeq.countBy id
        |> Seq.sortByDescending snd
        |> PSeq.toList

    for item in output do
        printfn "%A %A" (snd item) (fst item)

        