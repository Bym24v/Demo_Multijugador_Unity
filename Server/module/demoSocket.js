const config = require('./config');
const io = require('socket.io')(config.port);

const DemoSocket = {

  ListClients: [], // Array

  CClient: {}, // Objet

  Stat: () => {

    io.on('connection', (socket) => {

      socket.on('otherClient', () => {

        for (var i = 0; i < DemoSocket.ListClients.length; i++) {

          // Loop others clients / local
          socket.emit("otherClient", {
            name: DemoSocket.ListClients[i].name,
            pwd: DemoSocket.ListClients[i].pwd
          }) // End Emit otherClient

        } // end for

      }) // end otherClients


        console.log("Usuario Conectado" + DemoSocket.ListClients.length);

        socket.on('login', (data) => {
          //console.log("Login Packet >>> " + JSON.stringify(data));

          // Packet Client No Seguro
          cclient = {
            name: data.name,
            pwd: data.pwd
          }


          // Add List clients
          DemoSocket.ListClients.push(cclient);

          // Emit logn Local
          socket.emit('login', cclient);

          // Emit Broadcast Emit All clients
          socket.broadcast.emit("otherClient", cclient);

        }) // End login

        socket.on('disconnect', () => {

          // Emit client desconectado
          //socket.broadcast.emit("otherClientDisconnect", DemoSocket)

          console.log("Usuario desconectado" + DemoSocket.ListClients.length);

          for (var i = 0; i < DemoSocket.ListClients.length; i++) {

            if (DemoSocket.ListClients[i].name === CClient.name) {
              console.log("Cliente >> " + DemoSocket.ListClients[i].name + "se a desconectado");
              DemoSocket.ListClients.splice(i, 1); // Borrar Cliente de la lista de clientes
            }
          } // End for

          console.log("Usuario desconectado" + DemoSocket.ListClients.length);

        }) // end disconnect

    }) // End socket

  }
}


module.exports = DemoSocket;
