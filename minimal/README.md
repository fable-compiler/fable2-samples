# Fable 2 Minimal App

This is a simple Fable 2 app including an [Elmish](https://elmish.github.io/) counter with as little configuration as possible. If you want to see a more complex app, check [the Fulma demo](https://github.com/MangelMaxime/fulma-demo).

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0 or higher
* [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)

## Building and running the app

* Install JS dependencies: `npm install`
* Install F# dependencies: `dotnet restore src`
* Move to `src` directory to start Fable and Webpack dev server: `dotnet fable webpack-dev-server`
* After the first compilation is finished, in your browser open: http://localhost:8080/

Any modification you do to the F# code will be reflected in the web page after saving.

## Project structure

### npm

JS dependencies are declared in `package.json`, while `package-lock.json` is a lock file automatically generated.

### Webpack

[Webpack](https://webpack.js.org) is a JS bundler with extensions, like a static dev server that enables hot reloading on code changes. Fable interacts with Webpack through the `fable-loader`. Configuration for Webpack is defined in the `webpack.config.js` file.

### F#

The sample only contains two F# files: the project (.fsproj) and a source file (.fs) in the `src` folder.

### Web assets

The `index.html` file and other assets like an icon can be found in the `public` folder.
