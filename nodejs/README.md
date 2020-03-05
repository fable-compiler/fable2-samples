# Fable Node.js App

This is a simple Fable Node.js app.

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
* [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
* An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

## Building and running the app

* Install JS dependencies: `npm install`
* Build Node.js app `npm run build`
* Try Node.js app `node build/App.js`

## Project structure

### npm

JS dependencies are declared in `package.json`, while `package-lock.json` is a lock file automatically generated.

### Fable-splitter

[Fable-splitter]() is a standalone tool which outputs separated files instead of a single bundle. Here all the js files are put into the `build`  dir. And the main entry point is our `App.js` file.

### F#

The sample only contains two F# files: the project (.fsproj) and a source file (.fs) in the `src` folder.
