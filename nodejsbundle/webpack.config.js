var path = require("path");

var babelOptions = {
  presets: [
    ["@babel/preset-env", {
      "targets": {
        "node": true,
      },
    }]
  ],
};

console.log("Bundling function...");

module.exports = {
  mode: "production",
  target: "node",
  node: {
    __dirname: false,
    __filename: false,
  },
  entry: './src/App.fsproj',
  output: {
    path: path.join(__dirname, "./build"),
    filename: 'App.js',
    library:"app",
    libraryTarget: 'commonjs'
  },
  plugins: [ ],
  module: {
    rules: [{
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: [] 
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      }
    ]
  },
};