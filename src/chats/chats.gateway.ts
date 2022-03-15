import {WebSocketGateway, SubscribeMessage, MessageBody, WebSocketServer} from '@nestjs/websockets';
import { ChatsService } from './chats.service';
import { CreateChatDto } from './dto/create-chat.dto';
import { UpdateChatDto } from './dto/update-chat.dto';
import {Server} from "socket.io";

@WebSocketGateway(81,  {
  namespace: 'events',
  transports: ['websocket'],
  cors: {
    origin: '*',
  },
})
export class ChatsGateway {
  @WebSocketServer()
  server: Server;
  constructor(private readonly chatsService: ChatsService) {}

  @SubscribeMessage('events')
  listenForMessages(@MessageBody() data: string) {
    this.server.sockets.emit('receive_message', data);
  }

  @SubscribeMessage('findAllChats')
  findAll() {
    return this.chatsService.findAll();
  }

  @SubscribeMessage('findOneChat')
  findOne(@MessageBody() id: number) {
    return this.chatsService.findOne(id);
  }

  @SubscribeMessage('updateChat')
  update(@MessageBody() updateChatDto: UpdateChatDto) {
    return this.chatsService.update(updateChatDto.id, updateChatDto);
  }

  @SubscribeMessage('removeChat')
  remove(@MessageBody() id: number) {
    return this.chatsService.remove(id);
  }
}
