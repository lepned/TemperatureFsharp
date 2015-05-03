namespace TempMeasure

open System
open System.Drawing

module Types = 
    type Stat = 
        { Min : float
          Max : float
          Average : float }

module Data = 
    let rnd = Random()
    let temps = Array2D.init 24 365 (fun _ _ -> rnd.Next(-30, 35) |> float)

module Statistikk = 
    open Types
    open Data
    
    let dayaverage day = temps.[*, day] |> Array.average
    let daymin day = temps.[*, day] |> Array.min
    let daymax day = temps.[*, day] |> Array.max
    let yearaverage time = temps.[time, *] |> Array.average
    let yearmin time = temps.[time, *] |> Array.min
    let yearmax time = temps.[time, *] |> Array.max
    
    let createDayStat = 
        [| for day = 0 to Array2D.length2 temps - 1 do
               yield { Min = daymin day
                       Max = daymax day
                       Average = dayaverage day } |]
    
    let createTimeStat = 
        [| for time = 0 to Array2D.length1 temps - 1 do
               yield { Min = yearmin time
                       Max = yearmax time
                       Average = yearaverage time } |]

module Charting = 
    open FSharp.Charting
    open Types
    
    let chartLine title xaxis yaxis legend (data : float array) = 
        Chart.Line(data, legend)
        |> Chart.WithTitle(Text = title, InsideArea = false)
        |> Chart.WithXAxis(Title = xaxis, Min = 0.0)
        |> Chart.WithYAxis(Title = yaxis)
        |> Chart.WithLegend(Title = "Type", InsideArea = true)
    
    let chartList title xaxis yaxis (data : (float array * string) array) = 
        data
        |> Array.map (fun (arr, legend) -> chartLine title xaxis yaxis legend arr)
        |> Chart.Combine
        |> Chart.WithTitle(Text = title, InsideArea = false)
        |> Chart.WithXAxis(Title = xaxis, Min = 0.0)
        |> Chart.WithYAxis(Title = yaxis)
