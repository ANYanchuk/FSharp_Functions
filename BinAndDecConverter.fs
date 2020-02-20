open System.Text.RegularExpressions

let binToDec (origin:string) =
    if(Regex.IsMatch (origin, "^[10]*$")) then
        origin.ToCharArray()
        |> Array.rev
        |> Array.indexed
        |> Array.fold (fun a b -> a + (int(snd b) - 48)  * pown 2 (fst b)) 0
        |> Some
    else
        None

let decToBin = function 
    | 0 -> Some "0"
    | origin when origin < 0 -> None
    | origin -> origin 
                |> Seq.unfold (function 0 -> None | i -> Some (string (i % 2), i / 2)) 
                |> Seq.reduce (fun a b -> b + a) 
                |> Some