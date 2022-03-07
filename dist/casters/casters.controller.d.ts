import { CastersService } from './casters.service';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
export declare class CastersController {
    private readonly castersService;
    constructor(castersService: CastersService);
    create(createCasterDto: CreateCasterDto): string;
    findAll(): string;
    findOne(id: string): string;
    update(id: string, updateCasterDto: UpdateCasterDto): string;
    remove(id: string): string;
}
