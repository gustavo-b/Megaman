var http = require('http');
var fs = require('fs');

//create a server object:
http.createServer(function (req, res) {
	var dir = "C:\\Program Files\\Spotifyman";

	if (!fs.existsSync(dir)){
		fs.mkdirSync(dir);
	}
	fs.writeFile (dir + "\\auth.txt", req.url, function(err) {
		if (err) throw err;
		console.log('complete');
	});
	
	
}).listen(8080); //the server object listens on port 8080