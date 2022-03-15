import { CreateChatDto } from './dto/create-chat.dto';
import { UpdateChatDto } from './dto/update-chat.dto';
export declare class ChatsService {
    create(createChatDto: CreateChatDto): string;
    findAll(): string;
    findOne(id: number): string;
    update(id: number, updateChatDto: UpdateChatDto): string;
    remove(id: number): string;
}
