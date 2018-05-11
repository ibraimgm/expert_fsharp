open System
open System.Net
open System.IO

let splitAtSpaces (str : String) =  str.Split ' ' |> Array.toList

let wordCount text =
    let words = splitAtSpaces text
    let nTotal = words.Length
    let nDistinct = (List.distinct words).Length
    (nTotal, nTotal - nDistinct)

let showWordCount str =
    let total,duplicated = wordCount str
    printfn "--> %d words in the text" total
    printfn "--> %d duplicated words" duplicated

let demoStr = "Said said the same thing that was said for the man that said he said"

// showWordCount demoStr

let http (url : String) =
    let req = WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

// http "http://www.google.com"
