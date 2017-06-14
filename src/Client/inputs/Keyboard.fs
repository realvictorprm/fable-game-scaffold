namespace PixiTraining.Inputs

open Fable.Core
open Fable.Import.Browser

[<RequireQualifiedAccess>]
module Keyboard =

  // We use module + type + AutoOpen to not polluate the Keyboard module with all keys definitions
  [<AutoOpen>]
  module KeyMod =
    type KeyMod =
      | Alt
      | Control
      | Shift
      | None

  [<AutoOpen>]
  module Keys =
    type Keys =
      | Dead of int
      | Backspace
      | Enter
      | Control
      | Escape
      | Tab
      | Space
      | End
      | Home
      | ArrowLeft
      | ArrowUp
      | ArrowRight
      | ArrowDown
      | Delete
      | A
      | B
      | C
      | R

  let resolveKeyFromCode keycode =
    match keycode with
    | 8 -> Keys.Backspace
    | 9 -> Keys.Tab
    | 13 -> Keys.Enter
    | 17 -> Keys.Control
    | 27 -> Keys.Escape
    | 32 -> Keys.Space
    | 35 -> Keys.End
    | 36 -> Keys.Home
    | 37 -> Keys.ArrowLeft
    | 38 -> Keys.ArrowUp
    | 39 -> Keys.ArrowRight
    | 40 -> Keys.ArrowDown
    | 46 -> Keys.Delete
    | 65 -> Keys.A
    | 66 -> Keys.B
    | 67 -> Keys.C
    | 82 -> Keys.R
    | _ -> Keys.Dead keycode

  type Modifiers =
    { mutable Shift: bool
      mutable Control: bool
      mutable CommandLeft: bool
      mutable CommandRight: bool
      mutable Alt: bool
    }

    static member Initial =
      { Shift = false
        Control = false
        CommandLeft = false
        CommandRight = false
        Alt = false
      }

  type Record =
    { mutable KeysPressed: Set<Keys>
      mutable LastKeyCode: int
      mutable LastKeyValue: string
      mutable LastKeyIsPrintable: bool
      mutable LastKey: Keys
      Modifiers: Modifiers
    }

    static member Initial =
      { KeysPressed = Set.empty
        LastKeyCode = -1
        LastKeyValue = ""
        LastKeyIsPrintable = false
        LastKey = Keys.Dead -1
        Modifiers = Modifiers.Initial
      }

    member self.IsPress key =
      self.KeysPressed.Contains(key)

    member self.ClearLastKey () =
      self.LastKeyCode <- -1
      self.LastKeyValue <- ""
      self.LastKeyIsPrintable <- false
      self.LastKey <- Keys.Dead -1

  let Manager = Record.Initial

  let init (element: HTMLElement) preventDefault =
    let updateModifiers (e: KeyboardEvent) =
      Manager.Modifiers.Alt <- e.altKey
      Manager.Modifiers.Shift <- e.shiftKey
      Manager.Modifiers.Control <- e.ctrlKey
      Manager.Modifiers.CommandLeft <- e.keyCode = 224.
      Manager.Modifiers.CommandRight <- e.keyCode = 224.

    element.addEventListener_keydown(
      fun e ->
        let code = int e.keyCode
        let key = resolveKeyFromCode code

        Manager.LastKeyValue <- e.key
        Manager.LastKeyCode <- code
        // Here we try to determine if the key is printable or not
        // Should not be "Dead". Exemple first press on '^' is Dead
        // And the value should be of size [1,2] because we can add:
        // * One character at a time. Example: 'a', '!', '§'
        // * Two characters at a time. Example '^^', '^p'
        // Second case occured when pressing some keys in sequence.
        // Example:
        // * '^^' = '^' + '^'
        // * '^p' = '^' + 'p'
        // We also have to make sure the key is not F1..F12 so we exclude keycode range: [112,123]
        Manager.LastKeyIsPrintable <- 1 <= e.key.Length && e.key.Length <= 2 && (code < 112 || code > 123)
        Manager.LastKey <- key
        Manager.KeysPressed <- Set.add key Manager.KeysPressed
        // Update the Modifiers state
        updateModifiers e
        null
    )

    element.addEventListener_keyup(
      fun e ->
        let code = int e.keyCode

        Manager.KeysPressed <- Set.remove (resolveKeyFromCode code) Manager.KeysPressed
        // Update the Modifiers state
        updateModifiers e
        null
    )

    // If the user ask to prevent tab unloosing focus
    if preventDefault then
      element.addEventListener_keydown(
        fun e ->
          let code = int e.keyCode

          let shouldPreventFromCtrl =
            if e.ctrlKey then
              match resolveKeyFromCode code with
              | Keys.A -> true
              | _ -> false
            else
              false

          // If we pressed tab then preventDefault to not loose the focus
          if code = 9 || code = 8 || shouldPreventFromCtrl then
            e.preventDefault()
            unbox false
          else
            null
      )
