import { ChatsService } from './chats.service';
import { UpdateChatDto } from './dto/update-chat.dto';
import { Server } from "socket.io";
export declare class ChatsGateway {
    private readonly chatsService;
    server: Server;
    constructor(chatsService: ChatsService);
    listenForMessages(data: string): void;
    findAll(): string;
    findOne(id: number): string;
    update(updateChatDto: UpdateChatDto): string;
    remove(id: number): string;
}
