import { Server } from 'socket.io';
export declare class ChatGateway {
    server: Server;
    listenForMessages(data: string): void;
}
