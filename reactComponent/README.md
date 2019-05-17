# Fable React Component

This is a sample fable component which could be published as a stand alone React component. 

## Requirements
* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
* [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
* An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

## Building and running the app

* Install JS dependencies: `yarn`
* Start Webpack dev server: `yarn start` or `yarn build`
* Make the package visible on your local system using `yarn link`
```
yarn link v1.13.0
success Registered "fs-react-component".
info You can now run `yarn link "fs-react-component"` in the projects where you want to use this package and it will be used instead.
Done in 0.09s.
```

### Meanwhile...

* Create a new plain js/react project
* For this example I'll use [create-react-app](https://facebook.github.io/create-react-app/) to save some setup.

```
npx create-react-app my-app
cd my-app
yarn link "fs-react-component"
yarn start
```

* Now the fs-react-component is linked to my-app by node_modules
* Open App.js and add this import
```javascript
import { StandardComponent, FunComponent, Fable5FunComponent } from 'fs-react-component'
```
* Then use the component like any other react component
```html
    <StandardComponent name="standard" />
    <FunComponent name="bare" />
    <Fable5FunComponent name="Memo Component" />
```
* If you ran `yarn start` in both fs-react-component and my-app you should be able to make changes to index.fs and see them reflected in my-app automatically.
* See comments in the source about why you might prefer one component type over another.
* That's it 🎉

## Publishing
* Remember to change the package name in package.json
* `yarn login` with your npmjs.com credentials
* `yarn publish`
* Tell your friends