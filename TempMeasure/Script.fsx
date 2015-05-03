#load "C:\Users\LarsErik\Source\Repos\TemperatureFsharp\packages\FSharp.Charting.0.90.10\FSharp.Charting.fsx"
#load "Temp.fs"
open TempMeasure
open FSharp.Charting

let year = Statistikk.createDayStat 
let days = Statistikk.createTimeStat  

year |>Array.map (fun t -> t.Average) |> Chart.Line
days |>Array.map (fun t -> t.Average) |> Chart.Line
