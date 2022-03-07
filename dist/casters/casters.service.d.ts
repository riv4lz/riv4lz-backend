import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
export declare class CastersService {
    create(createCasterDto: CreateCasterDto): string;
    findAll(): string;
    findOne(id: number): string;
    update(id: number, updateCasterDto: UpdateCasterDto): string;
    remove(id: number): string;
}
