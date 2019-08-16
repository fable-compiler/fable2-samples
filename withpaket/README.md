# Fable Browser App

This is a simple Fable app which draws a grid into a canvas element. In order to use F# libraries from the .NET NuGet library store we use paket manager wich takes care of handling the downloading and the resolving of conflicts between libraries. 

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
* [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
* An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

## Building and running the app

* Install JS dependencies: `npm install`
* Install .NET dependencies: `.paket/paket install`
* Start Webpack dev server: `npx webpack-dev-server` or `npm start`
* After the first compilation is finished, in your browser open: http://localhost:8080/

Any modification you do to the F# code will be reflected in the web page after saving.

## Project structure

### npm

JS dependencies are declared in `package.json`, while `package-lock.json` is a lock file automatically generated.

### paket

[Paket](https://fsprojects.github.io/Paket/) 

> Paket is a dependency manager for .NET and mono projects, which is designed to work well with NuGet packages and also enables referencing files directly from Git repositories or any HTTP resource. It enables precise and predictable control over what packages the projects within your application reference.

.NET dependencies are declared in `paket.dependencies`. The `src/paket.references` lists the libraries actually used in the project. Since you can have several F# projects, we could have different custom `.paket` files for each project.

Last but not least, in the `.fsproj` file you can find a new node: `	<Import Project="..\.paket\Paket.Restore.targets" />` which just tells the compiler to look for the referenced libraries information from the `.paket/Paket.Restore.targets` file.

### Webpack

[Webpack](https://webpack.js.org) is a JS bundler with extensions, like a static dev server that enables hot reloading on code changes. Fable interacts with Webpack through the `fable-loader`. Configuration for Webpack is defined in the `webpack.config.js` file. Note this sample only includes basic Webpack configuration for development mode, if you want to see a more comprehensive configuration check the [Fable webpack-config-template](https://github.com/fable-compiler/webpack-config-template/blob/master/webpack.config.js).

### F#

The sample only contains two F# files: the project (.fsproj) and a source file (.fs) in the `src` folder.

### Web assets

The `index.html` file and other assets like an icon can be found in the `public` folder.
