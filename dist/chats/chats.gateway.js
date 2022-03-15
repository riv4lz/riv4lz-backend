"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ChatsGateway = void 0;
const websockets_1 = require("@nestjs/websockets");
const chats_service_1 = require("./chats.service");
const update_chat_dto_1 = require("./dto/update-chat.dto");
const socket_io_1 = require("socket.io");
let ChatsGateway = class ChatsGateway {
    constructor(chatsService) {
        this.chatsService = chatsService;
    }
    listenForMessages(data) {
        this.server.sockets.emit('receive_message', data);
    }
    findAll() {
        return this.chatsService.findAll();
    }
    findOne(id) {
        return this.chatsService.findOne(id);
    }
    update(updateChatDto) {
        return this.chatsService.update(updateChatDto.id, updateChatDto);
    }
    remove(id) {
        return this.chatsService.remove(id);
    }
};
__decorate([
    (0, websockets_1.WebSocketServer)(),
    __metadata("design:type", socket_io_1.Server)
], ChatsGateway.prototype, "server", void 0);
__decorate([
    (0, websockets_1.SubscribeMessage)('events'),
    __param(0, (0, websockets_1.MessageBody)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String]),
    __metadata("design:returntype", void 0)
], ChatsGateway.prototype, "listenForMessages", null);
__decorate([
    (0, websockets_1.SubscribeMessage)('findAllChats'),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], ChatsGateway.prototype, "findAll", null);
__decorate([
    (0, websockets_1.SubscribeMessage)('findOneChat'),
    __param(0, (0, websockets_1.MessageBody)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Number]),
    __metadata("design:returntype", void 0)
], ChatsGateway.prototype, "findOne", null);
__decorate([
    (0, websockets_1.SubscribeMessage)('updateChat'),
    __param(0, (0, websockets_1.MessageBody)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [update_chat_dto_1.UpdateChatDto]),
    __metadata("design:returntype", void 0)
], ChatsGateway.prototype, "update", null);
__decorate([
    (0, websockets_1.SubscribeMessage)('removeChat'),
    __param(0, (0, websockets_1.MessageBody)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Number]),
    __metadata("design:returntype", void 0)
], ChatsGateway.prototype, "remove", null);
ChatsGateway = __decorate([
    (0, websockets_1.WebSocketGateway)(81, {
        namespace: 'events',
        transports: ['websocket'],
        cors: {
            origin: '*',
        },
    }),
    __metadata("design:paramtypes", [chats_service_1.ChatsService])
], ChatsGateway);
exports.ChatsGateway = ChatsGateway;
//# sourceMappingURL=chats.gateway.js.map