# A web game scaffold for game developer happiness

This document describes how to use the repo for easily setting up your own custom game with Fable + F#.

## Requirements

- [Mono](http://www.mono-project.com/) on MacOS/Linux (on Windows .NET Framework is installed by default)
- [node.js](https://nodejs.org/) - JavaScript runtime
- [yarn](https://yarnpkg.com/) - Package manager for npm modules

> On OS X/macOS, make sure you have OpenSSL installed and symlinked correctly, as described here: [https://www.microsoft.com/net/core#macos](https://www.microsoft.com/net/core#macos).

[dotnet SDK 1.0.4](https://www.microsoft.com/net/core) is required but it'll be downloaded automatically by the build script if not installed (see below). Other tools like Paket or FAKE will also be installed by the build script.

## Development mode

This development stack is designed to be used with minimal tooling. An instance of Visual Studio Code together with the excellent [Ionide](http://ionide.io/) plugin should be enough.

Start the development mode with:

    > build.cmd run // on windows
    $ ./build.sh run // on unix

This command will call in **build.fsx** the target "Run". It will start in parallel:
- **dotnet watch run** in [src/Server](src/Server/Server) (note: Suave is launched on port **8085**)
- **dotnet fable webpack-dev-server** in [src/Client](src/Client) (note: the Webpack development server will serve files on http://localhost:8080)

Previously, the build script should download all dependencies like .NET Core SDK, Fable... If you have problems with the download of the .NET Core SDK via the `build.cmd` or `build.sh` script, please install the SDK manually from [here](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.0.4-download.md). Verify
that you have at least SDK version 1.0.4 installed (`dotnet --version`) and then rerun the build script.

You can now edit files in `src/Server` or `src/Client` and recompile + browser refresh will be triggered automatically.

![Development mode](https://cloud.githubusercontent.com/assets/57396/23174149/af93da32-f85b-11e6-8de2-01c274f54a27.gif)

Usually you can just keep this mode running and running. Just edit files, see the browser refreshing and commit + push with git.

## Technology stack

### Suave on .NET Core

The webserver backend is running as a [Suave.io](https://suave.io/) service on .NET Core.

In development mode the server is automatically restarted whenever a file in `src/Server` is saved.

### Pixi and Matter

Pixi.js and Matter.js are the core of the game development, they are providing fast 2D rendering and fast 2D physics.

### Fable

The [Fable](http://fable.io/) compiler is used to compile the F# client code to JavaScript so that it can run in the browser.

### Shared code between server and client

"Isomorphic F#" started a bit as a joke about [Isomorphic JavaScript](http://isomorphic.net/). The naming is really bad, but the idea to have the same code running on client and server is really interesting.
If you look at `src/Server/Shared/Domain.fs` then you will see code that is shared between client and server. On the server it is compiled to .NET core and for the client the Fable compiler is translating it into JavaScript.
This is a really convenient technique for a shared domain model.

## Testing

Start the full build (incl. UI tests) with:

    > build.cmd // on windows
    $ ./build.sh // on unix
    
## Additional tools

### FAKE

[FAKE](http://fsharp.github.io/FAKE/) is a build automation system with capabilities which are similar to make and rake. It's used to automate the build, test and deployment process. Look into `build.fsx` for details.

### Paket

[Paket](https://fsprojects.github.io/Paket/) is a dependency manager and allows easier management of the NuGet packages.

## Maintainer(s)

- [@realvictorprm](https://github.com/realvictorprm)
