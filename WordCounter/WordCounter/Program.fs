open System
open System.IO
open FSharp.Collections.ParallelSeq

let GetAllFiles (location : string) =
    (Directory.GetFiles(location, "*.txt"))
   
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

let arr = GetAllFiles userdirectory

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