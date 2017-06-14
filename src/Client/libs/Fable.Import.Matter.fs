namespace Fable.Import
open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.JS
open Fable.Import.Browser

#nowarn "1182"

module Matter =
    
    type IRenderDefinition =
        interface end 
    and RenderDefinition =
        | Controller of obj
        | [<CompiledName("engine")>] OptEngine of Engine
        | Element of HTMLElement
        | Canvas of HTMLCanvasElement
        | Options of IRendererOptions
        | Bounds of Bounds
        | Context of CanvasRenderingContext2D
        | Textures of obj option
        interface IRenderDefinition

    and  IRendererOptions =
        interface end

    and  RendererOptions =
        | Width of float
        | Height of float
        | HasBounds of bool
        | Wireframes of bool
        interface IRendererOptions

    and  IBodyDefinition =
        interface end

    and  BodyDefinition =
        | Angle of float
        | AngularSpeed of float
        | AngularVelocity of float
        | Area of float
        | Axes of ResizeArray<Vector>
        | Bounds of Bounds
        | Density of float
        | Force of Vector
        | Friction of float
        | FrictionAir of float
        | Id of float
        | Inertia of float
        | InverseInertia of float
        | InverseMass of float
        | IsSensor
        | IsSleeping
        | IsStatic
        | Label of string
        | Mass of float
        | Motion of float
        | Position of Vector
        | [<CompiledName("Render")>] OptRender of IBodyRenderOptions
        | Restitution of float
        | SleepThreshold of float
        | Slop of float
        | Speed of float
        | TimeScale of float
        | Torque of float
        | Type of string
        | Velocity of Vector
        | Vertices of ResizeArray<Vector>
        | Parts of ResizeArray<Body>
        | Parent of Body
        | FrictionStatic of float
        | CollisionFilter of ICollisionFilter
        interface IBodyDefinition

    and  IChamferableBodyDefinition =
        inherit IBodyDefinition

    and [<AllowNullLiteral>] [<Import("Axes","Matter")>] Axes() =
        static member fromVertices(vertices: ResizeArray<Vector>): ResizeArray<Vector> = jsNative
        static member rotate(axes: ResizeArray<Vector>, angle: float): unit = jsNative

    and [<AllowNullLiteral>] IChamfer =
        abstract radius: U2<float, ResizeArray<float>> option with get, set
        abstract quality: float option with get, set
        abstract qualityMin: float option with get, set
        abstract qualityMax: float option with get, set

    and [<AllowNullLiteral>] [<Import("Bodies","Matter")>] Bodies() =
        static member circle(x: float, y: float, radius: float, ?options: IBodyDefinition, ?maxSides: float): Body = jsNative
        static member polygon(x: float, y: float, sides: float, radius: float, ?options: IChamferableBodyDefinition list): Body = jsNative
        static member rectangle(x: float, y: float, width: float, height: float, ?options: IChamferableBodyDefinition list): Body = jsNative
        static member trapezoid(x: float, y: float, width: float, height: float, slope: float, ?options: IChamferableBodyDefinition list): Body = jsNative
        static member fromVertices(x: float, y: float, vertexSets: ResizeArray<ResizeArray<Vector>>, ?options: IBodyDefinition, ?flagInternal: bool, ?removeCollinear: float, ?minimumArea: float): Body = jsNative

    and [<AllowNullLiteral>] IBodyRenderOptions =
        abstract visible: bool option with get, set
        abstract sprite: IBodyRenderOptionsSprite option with get, set
        abstract fillStyle: string option with get, set
        abstract lineWidth: float option with get, set
        abstract strokeStyle: string option with get, set
        abstract opacity: float option with get, set

    and [<AllowNullLiteral>] IBodyRenderOptionsSprite =
        abstract texture: string with get, set
        abstract xScale: float with get, set
        abstract yScale: float with get, set

    and [<AllowNullLiteral>] [<Import("Body","Matter")>] Body() =
        member __.angle with get(): float = jsNative and set(v: float): unit = jsNative
        member __.angularSpeed with get(): float = jsNative and set(v: float): unit = jsNative
        member __.angularVelocity with get(): float = jsNative and set(v: float): unit = jsNative
        member __.area with get(): float = jsNative and set(v: float): unit = jsNative
        member __.axes with get(): ResizeArray<Vector> = jsNative and set(v: ResizeArray<Vector>): unit = jsNative
        member __.bounds with get(): Bounds = jsNative and set(v: Bounds): unit = jsNative
        member __.density with get(): float = jsNative and set(v: float): unit = jsNative
        member __.force with get(): Vector = jsNative and set(v: Vector): unit = jsNative
        member __.friction with get(): float = jsNative and set(v: float): unit = jsNative
        member __.frictionAir with get(): float = jsNative and set(v: float): unit = jsNative
        member __.id with get(): float = jsNative and set(v: float): unit = jsNative
        member __.inertia with get(): float = jsNative and set(v: float): unit = jsNative
        member __.inverseInertia with get(): float = jsNative and set(v: float): unit = jsNative
        member __.inverseMass with get(): float = jsNative and set(v: float): unit = jsNative
        member __.isSleeping with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.isStatic with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.label with get(): string = jsNative and set(v: string): unit = jsNative
        member __.mass with get(): float = jsNative and set(v: float): unit = jsNative
        member __.motion with get(): float = jsNative and set(v: float): unit = jsNative
        member __.position with get(): Vector = jsNative and set(v: Vector): unit = jsNative
        member __.render with get(): IBodyRenderOptions = jsNative and set(v: IBodyRenderOptions): unit = jsNative
        member __.restitution with get(): float = jsNative and set(v: float): unit = jsNative
        member __.sleepThreshold with get(): float = jsNative and set(v: float): unit = jsNative
        member __.slop with get(): float = jsNative and set(v: float): unit = jsNative
        member __.speed with get(): float = jsNative and set(v: float): unit = jsNative
        member __.timeScale with get(): float = jsNative and set(v: float): unit = jsNative
        member __.torque with get(): float = jsNative and set(v: float): unit = jsNative
        member __.``type`` with get(): string = jsNative and set(v: string): unit = jsNative
        member __.velocity with get(): Vector = jsNative and set(v: Vector): unit = jsNative
        member __.vertices with get(): ResizeArray<Vector> = jsNative and set(v: ResizeArray<Vector>): unit = jsNative
        member __.parts with get(): ResizeArray<Body> = jsNative and set(v: ResizeArray<Body>): unit = jsNative
        member __.parent with get(): Body = jsNative and set(v: Body): unit = jsNative
        member __.frictionStatic with get(): float = jsNative and set(v: float): unit = jsNative
        member __.collisionFilter with get(): ICollisionFilter = jsNative and set(v: ICollisionFilter): unit = jsNative
        static member applyForce(body: Body, position: Vector, force: Vector): unit = jsNative
        static member create(options: IBodyDefinition): Body = jsNative
        static member rotate(body: Body, rotation: float): unit = jsNative
        static member nextGroup(isNonColliding: bool): float = jsNative
        static member nextCategory(): float = jsNative
        static member set(body: Body, settings: obj, ?value: obj): unit = jsNative
        static member setMass(body: Body, mass: float): unit = jsNative
        static member setDensity(body: Body, density: float): unit = jsNative
        static member setInertia(body: Body, interna: float): unit = jsNative
        static member setVertices(body: Body, vertices: ResizeArray<Vector>): unit = jsNative
        static member setParts(body: Body, parts: ResizeArray<Body>, ?autoHull: bool): unit = jsNative
        static member setPosition(body: Body, position: Vector): unit = jsNative
        static member setAngle(body: Body, angle: float): unit = jsNative
        static member setVelocity(body: Body, velocity: Vector): unit = jsNative
        static member setAngularVelocity(body: Body, velocity: float): unit = jsNative
        static member setStatic(body: Body, isStatic: bool): unit = jsNative
        static member scale(body: Body, scaleX: float, scaleY: float, ?point: Vector): unit = jsNative
        static member translate(body: Body, translation: Vector): unit = jsNative
        static member update(body: Body, deltaTime: float, timeScale: float, correction: float): unit = jsNative

    and [<AllowNullLiteral>] IBound =
        abstract min: obj with get, set
        abstract max: obj with get, set

    and [<AllowNullLiteral>] [<Import("Bounds","Matter")>] Bounds() =
        static member create(vertices: Vertices): Bounds = jsNative
        static member update(bounds: Bounds, vertices: Vertices, velocity: Vector): unit = jsNative
        static member contains(bounds: Bounds, point: Vector): bool = jsNative
        static member overlaps(boundsA: Bounds, boundsB: Bounds): bool = jsNative
        static member translate(bounds: Bounds, vector: Vector): unit = jsNative
        static member shift(bounds: Bounds, position: Vector): unit = jsNative

    and [<AllowNullLiteral>] ICompositeDefinition =
        abstract bodies: ResizeArray<Body> option with get, set
        abstract composites: ResizeArray<Composite> option with get, set
        abstract constraints: ResizeArray<Constraint> option with get, set
        abstract id: float option with get, set
        abstract isModified: bool option with get, set
        abstract label: string option with get, set
        abstract parent: Composite option with get, set
        abstract ``type``: string option with get, set

    and [<AllowNullLiteral>] [<Import("Composite","Matter")>] Composite() =
        member __.bodies with get(): ResizeArray<Body> = jsNative and set(v: ResizeArray<Body>): unit = jsNative
        member __.composites with get(): ResizeArray<Composite> = jsNative and set(v: ResizeArray<Composite>): unit = jsNative
        member __.constraints with get(): ResizeArray<Constraint> = jsNative and set(v: ResizeArray<Constraint>): unit = jsNative
        member __.id with get(): float = jsNative and set(v: float): unit = jsNative
        member __.isModified with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.label with get(): string = jsNative and set(v: string): unit = jsNative
        member __.parent with get(): Composite = jsNative and set(v: Composite): unit = jsNative
        member __.``type`` with get(): string = jsNative and set(v: string): unit = jsNative
        static member add(composite: Composite, ``object``: U3<Body, Composite, Constraint>): Composite = jsNative
        static member allBodies(composite: Composite): ResizeArray<Body> = jsNative
        static member allComposites(composite: Composite): ResizeArray<Composite> = jsNative
        static member allConstraints(composite: Composite): ResizeArray<Composite> = jsNative
        static member clear(composite: Composite, keepStatic: bool, ?deep: bool): unit = jsNative
        static member create(?options: ICompositeDefinition): Composite = jsNative
        static member get(composite: Composite, id: float, ``type``: string): U3<Body, Composite, Constraint> = jsNative
        static member move(compositeA: Composite, objects: ResizeArray<U3<Body, Composite, Constraint>>, compositeB: Composite): Composite = jsNative
        static member rebase(composite: Composite): Composite = jsNative
        static member remove(composite: Composite, ``object``: U3<Body, Composite, Constraint>, ?deep: bool): Composite = jsNative
        static member setModified(composite: Composite, isModified: bool, ?updateParents: bool, ?updateChildren: bool): unit = jsNative
        static member translate(composite: Composite, translation: Vector, ?recursive: bool): unit = jsNative
        static member rotate(composite: Composite, rotation: float, point: Vector, ?recursive: bool): unit = jsNative
        static member scale(composite: Composite, scaleX: float, scaleY: float, point: Vector, ?recursive: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Composites","Matter")>] Composites() =
        static member car(xx: float, yy: float, width: float, height: float, wheelSize: float): Composite = jsNative
        static member chain(composite: Composite, xOffsetA: float, yOffsetA: float, xOffsetB: float, yOffsetB: float, options: obj): Composite = jsNative
        static member mesh(composite: Composite, columns: float, rows: float, crossBrace: bool, options: obj): Composite = jsNative
        member __.newtonsCradle(xx: float, yy: float, _number: float, size: float, length: float): Composite = jsNative
        static member pyramid(xx: float, yy: float, columns: float, rows: float, columnGap: float, rowGap: float, callback: Function): Composite = jsNative
        static member softBody(xx: float, yy: float, columns: float, rows: float, columnGap: float, rowGap: float, crossBrace: bool, particleRadius: float, particleOptions: obj, constraintOptions: obj): Composite = jsNative
        static member stack(xx: float, yy: float, columns: float, rows: float, columnGap: float, rowGap: float, callback: Function): Composite = jsNative

    and [<AllowNullLiteral>] IConstraintDefinition =
        abstract bodyA: Body option with get, set
        abstract bodyB: Body option with get, set
        abstract id: float option with get, set
        abstract label: string option with get, set
        abstract length: float option with get, set
        abstract pointA: Vector option with get, set
        abstract pointB: Vector option with get, set
        abstract render: IConstraintRenderDefinition option with get, set
        abstract stiffness: float option with get, set
        abstract ``type``: string option with get, set

    and [<AllowNullLiteral>] IConstraintRenderDefinition =
        abstract lineWidth: float with get, set
        abstract strokeStyle: string with get, set
        abstract visible: bool with get, set

    and [<AllowNullLiteral>] [<Import("Constraint","Matter")>] Constraint() =
        member __.bodyA with get(): Body = jsNative and set(v: Body): unit = jsNative
        member __.bodyB with get(): Body = jsNative and set(v: Body): unit = jsNative
        member __.id with get(): float = jsNative and set(v: float): unit = jsNative
        member __.label with get(): string = jsNative and set(v: string): unit = jsNative
        member __.length with get(): float = jsNative and set(v: float): unit = jsNative
        member __.pointA with get(): Vector = jsNative and set(v: Vector): unit = jsNative
        member __.pointB with get(): Vector = jsNative and set(v: Vector): unit = jsNative
        member __.render with get(): IConstraintRenderDefinition = jsNative and set(v: IConstraintRenderDefinition): unit = jsNative
        member __.stiffness with get(): float = jsNative and set(v: float): unit = jsNative
        member __.``type`` with get(): string = jsNative and set(v: string): unit = jsNative
        static member create(options: IConstraintDefinition): Constraint = jsNative

    and [<AllowNullLiteral>] IEngineDefinition =
        abstract positionIterations: float option with get, set
        abstract velocityIterations: float option with get, set
        abstract constraintIterations: float option with get, set
        abstract enableSleeping: bool option with get, set
        abstract timing: IEngineTimingOptions option with get, set
        abstract grid: Grid option with get, set
        abstract world: World option with get, set

    and [<AllowNullLiteral>] IEngineTimingOptions =
        abstract timeScale: float with get, set
        abstract timestamp: float with get, set

    and [<AllowNullLiteral>] [<Import("Engine","Matter")>] Engine() =
        member __.broadphase with get(): Grid = jsNative and set(v: Grid): unit = jsNative
        member __.constraintIterations with get(): float = jsNative and set(v: float): unit = jsNative
        member __.enabled with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.enableSleeping with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.pairs with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.positionIterations with get(): float = jsNative and set(v: float): unit = jsNative
        member __.render with get(): Render = jsNative and set(v: Render): unit = jsNative
        member __.timing with get(): IEngineTimingOptions = jsNative and set(v: IEngineTimingOptions): unit = jsNative
        member __.velocityIterations with get(): float = jsNative and set(v: float): unit = jsNative
        member __.world with get(): World = jsNative and set(v: World): unit = jsNative
        static member clear(engine: Engine): unit = jsNative
        static member create(?element: U2<HTMLElement, IEngineDefinition>, ?options: IEngineDefinition): Engine = jsNative
        static member create(?options: IEngineDefinition): Engine = jsNative
        static member merge(engineA: Engine, engineB: Engine): unit = jsNative
        static member update(engine: Engine, ?delta: float, ?correction: float): Engine = jsNative
        static member run(enige: Engine): unit = jsNative

    and [<AllowNullLiteral>] IGridDefinition =
        interface end

    and [<AllowNullLiteral>] [<Import("Grid","Matter")>] Grid() =
        static member create(?options: IGridDefinition): Grid = jsNative
        static member update(grid: Grid, bodies: ResizeArray<Body>, engine: Engine, forceUpdate: bool): unit = jsNative
        static member clear(grid: Grid): unit = jsNative

    and [<AllowNullLiteral>] IMouseConstraintDefinition =
        abstract ``constraint``: Constraint option with get, set
        abstract collisionFilter: ICollisionFilter option with get, set
        abstract body: Body option with get, set
        abstract mouse: Mouse option with get, set
        abstract ``type``: string option with get, set

    and [<AllowNullLiteral>] [<Import("MouseConstraint","Matter")>] MouseConstraint() =
        member __.``constraint`` with get(): Constraint = jsNative and set(v: Constraint): unit = jsNative
        member __.collisionFilter with get(): ICollisionFilter = jsNative and set(v: ICollisionFilter): unit = jsNative
        member __.body with get(): Body = jsNative and set(v: Body): unit = jsNative
        member __.mouse with get(): Mouse = jsNative and set(v: Mouse): unit = jsNative
        member __.``type`` with get(): string = jsNative and set(v: string): unit = jsNative
        static member create(engine: Engine, ?options: IMouseConstraintDefinition): MouseConstraint = jsNative

    and [<AllowNullLiteral>] [<Import("Pairs","Matter")>] Pairs() =
        static member clear(pairs: obj): obj = jsNative

    and [<AllowNullLiteral>] IPair =
        abstract id: float with get, set
        abstract bodyA: Body with get, set
        abstract bodyB: Body with get, set
        abstract contacts: obj with get, set
        abstract activeContacts: obj with get, set
        abstract separation: float with get, set
        abstract isActive: bool with get, set
        abstract timeCreated: float with get, set
        abstract timeUpdated: float with get, set
        abstract inverseMass: float with get, set
        abstract friction: float with get, set
        abstract frictionStatic: float with get, set
        abstract restitution: float with get, set
        abstract slop: float with get, set

    and [<AllowNullLiteral>] [<Import("Query","Matter")>] Query() =
        static member ray(bodies: ResizeArray<Body>, startPoint: Vector, endPoint: Vector, ?rayWidth: float): ResizeArray<obj> = jsNative
        static member region(bodies: ResizeArray<Body>, bounds: Bounds, ?outside: bool): ResizeArray<Body> = jsNative
        static member point(bodies: ResizeArray<Body>, point: Vector): ResizeArray<Body> = jsNative

    and [<AllowNullLiteral>] [<Import("Render","Matter")>] Render() =
        member __.controller with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.element with get(): HTMLElement = jsNative and set(v: HTMLElement): unit = jsNative
        member __.canvas with get(): HTMLCanvasElement = jsNative and set(v: HTMLCanvasElement): unit = jsNative
        member __.options with get(): IRendererOptions list = jsNative and set(v: IRendererOptions list ): unit = jsNative
        member __.bounds with get(): Bounds = jsNative and set(v: Bounds): unit = jsNative
        member __.context with get(): CanvasRenderingContext2D = jsNative and set(v: CanvasRenderingContext2D): unit = jsNative
        member __.textures with get(): obj = jsNative and set(v: obj): unit = jsNative
        static member create(options: IRenderDefinition list): Render = jsNative
        static member run(render: Render): unit = jsNative
        static member stop(render: Render): unit = jsNative
        static member setPixelRatio(render: Render, pixelRatio: float): unit = jsNative
        static member world(render: Render): unit = jsNative

    and [<AllowNullLiteral>] IRunnerOptions =
        abstract isFixed: bool option with get, set
        abstract delta: float option with get, set

    and [<AllowNullLiteral>] [<Import("Runner","Matter")>] Runner() =
        member __.enabled with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.isFixed with get(): bool = jsNative and set(v: bool): unit = jsNative
        member __.delta with get(): float = jsNative and set(v: float): unit = jsNative
        static member create(options: IRunnerOptions): Runner = jsNative
        static member run(runner: Runner, engine: Engine): Runner = jsNative
        static member run(engine: Engine): Runner = jsNative
        static member tick(runner: Runner, engine: Engine, time: float): unit = jsNative
        static member stop(runner: Runner): unit = jsNative
        static member start(runner: Runner, engine: Engine): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Sleeping","Matter")>] Sleeping() =
        static member set(body: Body, isSleeping: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Svg","Matter")>] Svg() =
        static member pathToVertices(path: SVGPathElement, sampleLength: float): ResizeArray<Vector> = jsNative

    and [<AllowNullLiteral>] [<Import("Vector","Matter")>] Vector() =
        member __.x with get(): float = jsNative and set(v: float): unit = jsNative
        member __.y with get(): float = jsNative and set(v: float): unit = jsNative
        static member create(?x: float, ?y: float): Vector = jsNative
        static member clone(vector: Vector): Vector = jsNative
        static member cross3(vectorA: Vector, vectorB: Vector, vectorC: Vector): float = jsNative
        static member add(vectorA: Vector, vectorB: Vector, ?output: Vector): Vector = jsNative
        static member angle(vectorA: Vector, vectorB: Vector): float = jsNative
        static member cross(vectorA: Vector, vectorB: Vector): float = jsNative
        static member div(vector: Vector, scalar: float): Vector = jsNative
        static member dot(vectorA: Vector, vectorB: Vector): float = jsNative
        static member magnitude(vector: Vector): float = jsNative
        static member magnitudeSquared(vector: Vector): float = jsNative
        static member mult(vector: Vector, scalar: float): Vector = jsNative
        static member neg(vector: Vector): Vector = jsNative
        static member normalise(vector: Vector): Vector = jsNative
        static member perp(vector: Vector, ?negate: bool): Vector = jsNative
        static member rotate(vector: Vector, angle: float): Vector = jsNative
        static member rotateAbout(vector: Vector, angle: float, point: Vector, ?output: Vector): Vector = jsNative
        static member sub(vectorA: Vector, vectorB: Vector, ?optional: Vector): Vector = jsNative

    and [<AllowNullLiteral>] [<Import("Vertices","Matter")>] Vertices() =
        static member mean(vertices: ResizeArray<Vector>): ResizeArray<Vector> = jsNative
        static member clockwiseSort(vertices: ResizeArray<Vector>): ResizeArray<Vector> = jsNative
        static member isConvex(vertices: ResizeArray<Vector>): bool = jsNative
        static member hull(vertices: ResizeArray<Vector>): ResizeArray<Vector> = jsNative
        static member area(vertices: ResizeArray<Vector>, signed: bool): float = jsNative
        static member centre(vertices: ResizeArray<Vector>): Vector = jsNative
        static member chamfer(vertices: ResizeArray<Vector>, radius: U2<float, ResizeArray<float>>, quality: float, qualityMin: float, qualityMax: float): unit = jsNative
        static member contains(vertices: ResizeArray<Vector>, point: Vector): bool = jsNative
        static member create(points: ResizeArray<Vector>, body: Body): unit = jsNative
        static member fromPath(path: string, body: Body): ResizeArray<Vector> = jsNative
        static member inertia(vertices: ResizeArray<Vector>, mass: float): float = jsNative
        static member rotate(vertices: ResizeArray<Vector>, angle: float, point: Vector): unit = jsNative
        static member scale(vertices: ResizeArray<Vector>, scaleX: float, scaleY: float, point: Vector): unit = jsNative
        static member translate(vertices: ResizeArray<Vector>, vector: Vector, scalar: float): unit = jsNative

    and [<AllowNullLiteral>] IWorldDefinition =
        inherit ICompositeDefinition
        abstract gravity: Gravity option with get, set
        abstract bounds: Bounds option with get, set

    and [<AllowNullLiteral>] Gravity =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract create: ?x: float * ?y: float -> Vector
        abstract clone: vector: Vector -> Vector
        abstract cross3: vectorA: Vector * vectorB: Vector * vectorC: Vector -> float
        abstract add: vectorA: Vector * vectorB: Vector * ?output: Vector -> Vector
        abstract angle: vectorA: Vector * vectorB: Vector -> float
        abstract cross: vectorA: Vector * vectorB: Vector -> float
        abstract div: vector: Vector * scalar: float -> Vector
        abstract dot: vectorA: Vector * vectorB: Vector -> float
        abstract magnitude: vector: Vector -> float
        abstract magnitudeSquared: vector: Vector -> float
        abstract mult: vector: Vector * scalar: float -> Vector
        abstract neg: vector: Vector -> Vector
        abstract normalise: vector: Vector -> Vector
        abstract perp: vector: Vector * ?negate: bool -> Vector
        abstract rotate: vector: Vector * angle: float -> Vector
        abstract rotateAbout: vector: Vector * angle: float * point: Vector * ?output: Vector -> Vector
        abstract sub: vectorA: Vector * vectorB: Vector * ?optional: Vector -> Vector
        abstract scale: float with get, set

    and [<AllowNullLiteral>] [<Import("World","Matter")>] World() =
        inherit Composite()
        member __.gravity with get(): Gravity = jsNative and set(v: Gravity): unit = jsNative
        member __.bounds with get(): Bounds = jsNative and set(v: Bounds): unit = jsNative
        static member add(world: World, body: obj): World = jsNative
        static member addBody(world: World, body: Body): World = jsNative
        static member addComposite(world: World, composite: Composite): World = jsNative
        static member addConstraint(world: World, ``constraint``: Constraint): World = jsNative
        static member clear(world: World, keepStatic: bool): unit = jsNative
        static member create(options: IWorldDefinition): World = jsNative

    and [<AllowNullLiteral>] ICollisionFilter =
        abstract category: float with get, set
        abstract mask: float with get, set
        abstract group: float with get, set

    and [<AllowNullLiteral>] IMousePoint =
        abstract x: float with get, set
        abstract y: float with get, set

    and [<AllowNullLiteral>] [<Import("Mouse","Matter")>] Mouse() =
        member __.element with get(): HTMLElement = jsNative and set(v: HTMLElement): unit = jsNative
        member __.absolute with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.position with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.mousedownPosition with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.mouseupPosition with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.offset with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.scale with get(): IMousePoint = jsNative and set(v: IMousePoint): unit = jsNative
        member __.wheelDelta with get(): float = jsNative and set(v: float): unit = jsNative
        member __.button with get(): float = jsNative and set(v: float): unit = jsNative
        member __.pixelRatio with get(): float = jsNative and set(v: float): unit = jsNative
        static member create(element: HTMLElement): Mouse = jsNative
        static member setElement(mouse: Mouse, element: HTMLElement): unit = jsNative
        static member clearSourceEvents(mouse: Mouse): unit = jsNative
        static member setOffset(mouse: Mouse, offset: Vector): unit = jsNative
        static member setScale(mouse: Mouse, scale: Vector): unit = jsNative

    and [<AllowNullLiteral>] IEvent<'T> =
        abstract name: string with get, set
        abstract source: 'T with get, set

    and [<AllowNullLiteral>] IEventComposite<'T> =
        inherit IEvent<'T>
        abstract ``object``: obj with get, set

    and [<AllowNullLiteral>] IEventTimestamped<'T> =
        inherit IEvent<'T>
        abstract timestamp: float with get, set

    and [<AllowNullLiteral>] IEventCollision<'T> =
        inherit IEventTimestamped<'T>
        abstract pairs: ResizeArray<IPair> with get, set

    and [<AllowNullLiteral>] [<Import("Events","Matter")>] Events() =
        [<Emit("Matter.Events.on($0,'sleepStart',$1...)")>] static member on_sleepStart(engine: Engine, callback: Func<IEvent<Body>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'sleepEnd',$1...)")>] static member on_sleepEnd(engine: Engine, callback: Func<IEvent<Body>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeAdd',$1...)")>] static member on_beforeAdd(engine: Engine, callback: Func<IEventComposite<Composite>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterAdd',$1...)")>] static member on_afterAdd(engine: Engine, callback: Func<IEventComposite<Composite>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeRemove',$1...)")>] static member on_beforeRemove(engine: Engine, callback: Func<IEventComposite<Composite>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterRemove',$1...)")>] static member on_afterRemove(engine: Engine, callback: Func<IEventComposite<Composite>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterUpdate',$1...)")>] static member on_afterUpdate(engine: Engine, callback: Func<IEventTimestamped<Engine>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeRender',$1...)")>] static member on_beforeRender(engine: Engine, callback: Func<IEventTimestamped<Render>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterRender',$1...)")>] static member on_afterRender(engine: Engine, callback: Func<IEventTimestamped<Render>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeUpdate',$1...)")>] static member on_beforeUpdate(engine: Engine, callback: Func<IEventTimestamped<Engine>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'collisionActive',$1...)")>] static member on_collisionActive(engine: Engine, callback: Func<IEventCollision<Engine>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'collisionEnd',$1...)")>] static member on_collisionEnd(engine: Engine, callback: Func<IEventCollision<Engine>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'collisionStart',$1...)")>] static member on_collisionStart(engine: Engine, callback: Func<IEventCollision<Engine>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeTick',$1...)")>] static member on_beforeTick(engine: Engine, callback: Func<IEventTimestamped<Runner>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'tick',$1...)")>] static member on_tick(engine: Engine, callback: Func<IEventTimestamped<Runner>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterTick',$1...)")>] static member on_afterTick(engine: Engine, callback: Func<IEventTimestamped<Runner>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'beforeRender',$1...)")>] static member on_beforeRender(engine: Engine, callback: Func<IEventTimestamped<Runner>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'afterRender',$1...)")>] static member on_afterRender(engine: Engine, callback: Func<IEventTimestamped<Runner>, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'mousedown',$1...)")>] static member on_mousedown(engine: Engine, callback: Func<obj, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'mousemove',$1...)")>] static member on_mousemove(engine: Engine, callback: Func<obj, unit>): unit = jsNative
        [<Emit("Matter.Events.on($0,'mouseup',$1...)")>] static member on_mouseup(engine: Engine, callback: Func<obj, unit>): unit = jsNative
        static member on(obj: obj, name: string, callback: Func<obj, unit>): unit = jsNative
        static member off(obj: obj, eventName: string, callback: Func<obj, unit>): unit = jsNative
        static member trigger(``object``: obj, eventNames: string, ?``event``: Func<obj, unit>): unit = jsNative
