#load @"C:\Users\LarsErik\Source\Repos\TemperatureFsharp\packages\FSharp.Charting.0.90.10\FSharp.Charting.fsx"
#load "Temp.fs"

open TempMeasure
open FSharp.Charting

let year = Statistikk.createDayStat
let hours = Statistikk.createTimeStat
let avg = year |> Array.map (fun t -> t.Average)
let min = year |> Array.map (fun t -> t.Min)
let max = year |> Array.map (fun t -> t.Max)

let list = 
    [| avg, "Average"
       min, "Min"
       max, "Max" |]

Charting.chartLine "Daily temperatures" "Days" "Temp" "Type" avg
Charting.chartList "Daily temperatures" "Days" "Temp" list
