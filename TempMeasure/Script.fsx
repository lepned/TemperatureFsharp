#load "C:\Users\LarsErik\Source\Repos\TemperatureFsharp\packages\FSharp.Charting.0.90.10\FSharp.Charting.fsx"
#load "Temp.fs"
open TempMeasure
open FSharp.Charting

open Data
open Statistikk

//script tests
let res = yearaverage 1
let maks = yearmax 1
let minn = yearmin 1
let resday = dayaverage 1
let resmaks = daymax 1
let resmin = daymin 1

let year = Statistikk.createDayStat 
let days = Statistikk.createTimeStat  

year |>Array.map (fun t -> t.Average) |> Chart.Line
days |>Array.map (fun t -> t.Average) |> Chart.Line
