import { CastersService } from "./casters.service";
import { CreateCasterDto } from "./dto/create-caster.dto";
export declare class AuthService {
    private castersService;
    constructor(castersService: CastersService);
    signup(createCasterDto: CreateCasterDto): Promise<import("./entities/caster.entity").Caster>;
    singin(): void;
}
