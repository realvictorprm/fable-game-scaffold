namespace PixiTraining

open Fable
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

open Fable.Import.PIXI
 
open PixiTraining.Inputs
open PixiTraining.Engine

open System

module Main =

  type DummyGame (engine) =
    inherit Scene(engine)
   
    let rand = Random()

    member val InfoText: Fable.Import.PIXI.Text = Unchecked.defaultof<PIXI.Text> with get, set

    member self.Init () =
      // Add here the game initalization code
      self.InfoText <- Fable.Import.PIXI.Text("Dummy")
      self.GraphicRoot.addChild(self.InfoText) |> ignore
      self

    member self.Update(dt: float) =
      // Add you game logic here
      ()

  // Create and init the engine instance
  let engine = Engine()
  engine.Init()

  let scene = DummyGame(engine).Init()
  engine.SetScene(scene)
  engine.Start()
