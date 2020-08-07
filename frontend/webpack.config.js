const path = require("path");
const HTMLWebpackPlugin = require("html-webpack-plugin");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = {
  context: path.resolve(__dirname, "src"),
  mode: "development",
  entry: "./js/app.js",
  output: {
    filename: "bundle.js",
    path: path.resolve(__dirname, "build"),
  },

  module: {
    rules: [
      {
        test: /\.css$/,
        use: ExtractTextPlugin.extract({
          fallback: "style-loader",
          use: "css-loader",
        }),
      },
    ],
  },

  devServer: {
    port: 4000,
  },

  plugins: [
    new HTMLWebpackPlugin({
      template: "./html/index.html",
    }),
    new ExtractTextPlugin("style.css"),
  ],
};
