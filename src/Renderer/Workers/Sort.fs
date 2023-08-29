module Workers.Sort

open Feliz.UseWorker

let rng = System.Random()

let sortNumbers' () =
    Array.init 3000000 (fun _ -> rng.NextDouble() * 1000000.)
    |> Array.sort
    |> Array.sum
    |> int
    |> fun i -> printfn "From worker: %d" i; i

let sortNumbers = WorkerFunc.Create("Sort", "sortNumbers", sortNumbers')