﻿module Ploeh.Kata.MaîtreD

open System

type Table = { Seats : int }

type Reservation = {
    Date : DateTime
    Name : string
    Email : string
    Quantity : int }

let canAccept tables reservations { Quantity = q; Date = d } =
    let largestTable = tables |> Seq.map (fun t -> t.Seats) |> Seq.max
    let capacity = tables |> Seq.sumBy (fun t -> t.Seats)
    let relevantReservations =
        Seq.filter (fun r -> r.Date.Date = d.Date) reservations
    let reservedSeats = Seq.sumBy (fun r -> r.Quantity) relevantReservations
    q <= largestTable && reservedSeats + q <= capacity