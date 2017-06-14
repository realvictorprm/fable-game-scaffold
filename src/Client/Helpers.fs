namespace PixiTraining

open Fable.Core
open Fable.Import
open Fable.Import.PIXI
open Fable.PowerPack
open System

[<AutoOpen>]
module Helpers =

  type Behavior = Func<ESprite, float, bool>

  and ESprite(t: Texture, id: string, behaviors: Behavior list) =
    inherit Sprite(t)
    let mutable _behaviors = behaviors
    let mutable _disposed = false
    let mutable _prevTime = 0.

    member self.Id = id
    member self.IsDisposed = _disposed

    member self.AddBehavior(b:Behavior) =
      _behaviors <- b :: _behaviors

    member self.Update(dt: float) =
        let behaviors = _behaviors
        _behaviors <- []
        let mutable notCompletedBehaviors = []
        let dt =
          let tmp = _prevTime
          _prevTime <- dt
          if tmp = 0. then 0. else dt - tmp
        for b in behaviors do
          let complete = b.Invoke(self, dt)
          if not complete then
            notCompletedBehaviors <- b :: notCompletedBehaviors
        _behaviors <- _behaviors @ notCompletedBehaviors

    interface IDisposable with
      member self.Dispose() =
        if not _disposed then
          _disposed <- true
          self.parent.removeChild(self) |> ignore

  type Vector (?x, ?y) =
    let x = defaultArg x 0.
    let y = defaultArg y 0.

    member self.X
      with get () = x

    member self.Y
      with get () = y

    member self.Length() =
      Math.Sqrt(self.X * self.X + self.Y * self.Y)

    member self.Normalize() =
      let length = self.Length()
      new Vector(self.X / length, self.Y / length)

    static member (+) (a: Vector, b: Vector) =
      new Vector(a.X + b.X, a.Y + b.Y)

    static member (-) (a: Vector, b: Vector) =
      new Vector(a.X - b.X, a.Y - b.Y)

    static member (*) (s, a: Vector) =
      new Vector(s * a.X, s * a.Y)


    type Math with
      static member DegreesToRadian
        with get () = Math.PI / 180.

      static member RadianToDegrees
        with get () = 180. / Math.PI

