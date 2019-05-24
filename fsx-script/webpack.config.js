const path = require("path");

module.exports = {
    entry: './src/App.fsx',
    output: {
        path: path.join(__dirname, "./public"),
        filename: "bundle.js",
    },
    mode: "development",
    devServer: {
        contentBase: "./public",
        port: 8080,
    },
    module: {
        rules: [
            {
                test: /\.fs(x|proj)?$/,
                use: {
                    loader: "fable-loader"
                }
            }
        ]
    },
    externals: {
        "react": "React",
        "react-dom": "ReactDOM",
    }
};
