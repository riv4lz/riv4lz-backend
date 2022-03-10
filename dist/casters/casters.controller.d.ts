import { CastersService } from './casters.service';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { AuthService } from "./auth.service";
export declare class CastersController {
    private readonly castersService;
    private readonly authService;
    constructor(castersService: CastersService, authService: AuthService);
    create(createCasterDto: CreateCasterDto): Promise<import("./entities/caster.entity").Caster>;
    findAll(): Promise<import("./entities/caster.entity").Caster[]>;
    findOne(id: string): Promise<import("./entities/caster.entity").Caster>;
    update(id: string, updateCasterDto: UpdateCasterDto): Promise<import("./entities/caster.entity").Caster>;
    remove(id: string): Promise<import("./entities/caster.entity").Caster>;
}
