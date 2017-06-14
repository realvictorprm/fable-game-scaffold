namespace PixiTraining

open Fable
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

open PixiTraining.Inputs

open Fable.Import.PIXI
 
open System 

module Engine =

  type Scene (engine) =
    member val GraphicRoot : PIXI.Container = PIXI.Container() with get
    member val Engine : Engine = engine with get, set

    member self.Init() =
      self

    member self.Update(_: float) =
      ()

  and Engine () =
    member val Renderer = Unchecked.defaultof<PIXI.WebGLRenderer> with get, set
    member val Canvas = Unchecked.defaultof<Browser.HTMLCanvasElement> with get, set
    member val StartDate : DateTime = DateTime.Now with get, set
    member val LastTickDate = 0. with get, set
    member val DeltaTime = 0. with get, set
    member val Scene: Scene option = None with get, set

    member self.Init () =
      let options = createEmpty<RendererOptions>
      options.BackgroundColor <- (float 0x9999bb)
      options.Resolution <- 1.
      options.Antialias <- true
      // Init the renderer
      self.Renderer <- WebGLRenderer(800., 600., options)
      // Init the canvas
      self.Canvas <- self.Renderer.view
      self.Canvas.setAttribute("tabindex", "1")
      self.Canvas.id <- "game"

      self.Canvas.addEventListener_click(fun ev ->
        self.Canvas.focus()
        null
      )

      Browser.document.body
        .appendChild(self.Canvas) |> ignore

      Mouse.init self.Canvas
      Keyboard.init self.Canvas true

      self.Canvas.focus()

    member self.Start() =
      self.StartDate <- DateTime.Now
      self.RequestUpdate()

    member self.RequestUpdate() =
      Browser.window.requestAnimationFrame(fun dt -> self.Update(dt)) |> ignore

    member self.Update(dt: float) =
      match self.Scene with
      | Some scene ->
          scene.Update(dt)
          self.Renderer.render(scene.GraphicRoot)
      | None -> Browser.console.warn "No scene."
      self.RequestUpdate()

    member self.SetScene(scene) =
      self.Scene <- Some scene
