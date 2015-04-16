namespace TempMeasure

open System

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
    
    let Dayaverage day = temps.[*, day] |> Array.average
    let Daymin day = temps.[*, day] |> Array.min
    let Daymax day = temps.[*, day] |> Array.max
    let Yearaverage time = temps.[time, *] |> Array.average
    let Yearmin time = temps.[time, *] |> Array.min
    let Yearmax time = temps.[time, *] |> Array.max
    
    let createDayStat = 
        [| for day = 0 to (temps.[*, 0].Length - 1) do
               yield { Min = Daymin day
                       Max = Daymax day
                       Average = Dayaverage day } |]
    
    let createTimeStat = 
        [| for time = 0 to temps.[0, *].Length - 1 do
               yield { Min = Yearmin time
                       Max = Yearmax time
                       Average = Yearaverage time } |]
    
    let arr = [| 1..10 |]
    let list = [ 1..10 ]
    let seq = { 1..10 }
    
    type Ramin = 
        { Id : int
          Alder : int }
    
    let ram = 
        { Id = 1
          Alder = 24 }
    
    let eldreRam = {ram with Alder = 23}



module Test = 
    open Data
    open Statistikk
    
    //let res1 = temps 
    //let row1 = temps.[1,*]
    //let row1Col2 = temps.[1,2]
    let res = Yearaverage 1
    let maks = Yearmax 1
    let minn = Yearmin 1
    let resday = Dayaverage 1
    let resmaks = Daymax 1
    let resmin = Daymin 1
