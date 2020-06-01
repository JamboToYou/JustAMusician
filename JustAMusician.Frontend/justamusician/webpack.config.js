const path = require("path");

module.exports = {
	entry: "./src/index.jsx",
	output: {
		path: path.join(__dirname, "/public"),
			filename: "index.js"
		},
		module: {
			rules: [
			{
				test: [ /\.js$/, /\.jsx$/ ],
				exclude: /node_modules/,
				use: {
					loader: "babel-loader"
				},
			},
			{
				test: /\.css$/,
				use: ["style-loader", "css-loader"]
			},
			{
				test: /\.(png|svg|jpg|gif)$/,
				use: [
					'file-loader',
				],
			},
			]
		},
		devServer: {
			contentBase: path.join(__dirname, 'public'),
				compress: true,
				port: 8080,
				historyApiFallback: true,
			}
		};