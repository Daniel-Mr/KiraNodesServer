using KiraNodeServer.Dtos;
using KiraNodeServer.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace KiraNodeServer.WebSockets
{
    public class NodeHandler : WebSocketHandler
    {
        public NodeHandler(WebSocketManager webSocketConnectionManager) : base(webSocketConnectionManager) { }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);           
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {

            var socketId = WebSocketConnectionManager.GetId(socket);
            var message = $"{Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            EventDto input;

            try
            {
                input = JsonConvert.DeserializeObject<EventDto>(message);
            }
            catch (Exception)
            {
                input = new EventDto { };
            }

            switch (input.@event)
            {
                case NodesEvents.OnConnected:
                    {
                        NodesManager manager = new NodesManager();

                        string output = JsonConvert.SerializeObject(new EventDto { @event = NodesEvents.OnConnected, d1 = "Node " + input.d1 + " is now connected with address " + socketId });

                        if (input.d1 != "WebClient")
                        {
                            manager.Insert(new Node { Id = input.d1, Name = input.d1, SocketId = socketId });
                        }

                        await SendMessageAsync(socketId, output);

                        break;
                    }
                case NodesEvents.OnToggle:
                    {
                        string clientId = input.d2;

                        NodesManager mgr = new NodesManager();
                        
                        var node = mgr.Get(input.d2);

                        if (node != null)
                        {
                            clientId = node.SocketId;
                        }

                        string output = JsonConvert.SerializeObject(new EventDto { @event = NodesEvents.OnToggle, d1 = input.d1, d2 = socketId, d3 = input.d3 });

                        await SendMessageAsync(clientId, output);

                        break;
                    }
                default:
                    break;
            }

            await Task.FromResult(0);

        }
    }
}
