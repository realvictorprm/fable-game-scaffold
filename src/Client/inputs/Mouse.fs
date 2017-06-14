namespace PixiTraining.Inputs

open Fable.Core
open Fable.Import.Browser

[<RequireQualifiedAccess>]
module Mouse =

  /// Just a alias type
  type ButtonState = bool

  [<RequireQualifiedAccess>]
  module Cursor =
      let Alias = "alias"
      let AllScroll = "all-scroll"
      let Auto = "auto"
      let Cell = "cell"
      let ContextMenu = "context-menu"
      let ColResize = "col-resize"
      let Copy = "copy"
      let Crosshair = "crosshair"
      let Default = "default"
      let EResize = "e-resize"
      let EwResize = "ew-resize"
      let Grab = "grab"
      let Grabbing = "grabbing"
      let Help = "help"
      let Move = "move"
      let NResize = "n-resize"
      let NeResize = "ne-resize"
      let NeswResize = "nesw-resize"
      let NsResize = "ns-resize"
      let NwResize = "nw-resize"
      let NwseResize = "nwse-resize"
      let NoDrop = "no-drop"
      let None = "none"
      let NotAllowed = "not-allowed"
      let Pointer = "pointer"
      let Progress = "progress"
      let RowResize = "row-resize"
      let SResize = "s-resize"
      let SeResize = "se-resize"
      let SwResize = "sw-resize"
      let Text = "text"
      let URL = "URL"
      let VerticalText = "vertical-text"
      let WResize = "w-resize"
      let Wait = "wait"
      let ZoomIn = "zoom-in"
      let ZoomOut = "zoom-out"
      let Initial = "initial"
      let Inherit = "inherit"

  /// Record used to store Mouse state
  type Record =
    { mutable X: float
      mutable Y: float
      mutable Left: ButtonState
      mutable Right: ButtonState
      mutable Middle: ButtonState
      mutable IsDragging: bool
      mutable HasBeenInitiated: bool
      mutable Element: HTMLElement
    }

    /// Initial state of Mouse
    static member Initial =
      { X = 0.
        Y = 0.
        Left = false
        Right = false
        Middle = false
        IsDragging = false
        HasBeenInitiated = false
        Element = window.document.body
      }

    member self.HitRegion (x, y, w, h) =
      self.X > x
      && self.X <= x + w
      && self.Y > y
      && self.Y < y + h

    member self.SetCursor cursor =
      self.Element.style.cursor <- cursor

    member self.ResetCursor () =
      self.Element.style.cursor <- Cursor.Auto


  /// Variable used to access current Mouse state
  let Manager = Record.Initial

  /// Init the Mouse module to map Mouse state
  /// * element: Element used to listem the Mouse events
  let init (element: HTMLElement) =
    // If the Manager has not been Initiated
    if not Manager.HasBeenInitiated then
      Manager.Element <- element

      /// Attach handler to Mouse down event
      element.addEventListener_mousedown(
        (
          fun ev ->
            match ev.which with
            | 1. -> Manager.Left <- true
            | 2. -> Manager.Middle <- true
            | 3. -> Manager.Right <- true
            | _ -> failwith "Not supported button"
            null
        )
      )

      /// Attach handler to Mouse up event
      element.addEventListener_mouseup(
        (
          fun ev ->
            match ev.which with
            | 1. ->
              Manager.Left <- false
              Manager.IsDragging <- false
            | 2. -> Manager.Middle <- false
            | 3. -> Manager.Right <- false
            | _ -> failwith "Not supported button"
            null
        )
      )

      /// Attach handler to Mouse move event
      element.addEventListener_mousemove(
        (
          fun ev ->
            // Update position
            Manager.X <- ev.offsetX
            Manager.Y <- ev.offsetY
            // Update dragging state
            if Manager.Left then
              Manager.IsDragging <- true
            null
        )
      )
      // Tag that event listener has been set
      Manager.HasBeenInitiated <- true
