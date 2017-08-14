const config = require('./config');
const socket = require('socket.io')(config.port);

const DemoSocket = {


  Stat: () => {
    console.log("Start");
  }
}


module.exports = DemoSocket;
