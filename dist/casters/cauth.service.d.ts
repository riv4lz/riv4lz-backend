import { CastersService } from "./casters.service";
import { CreateCasterDto } from "./dto/create-caster.dto";
import { LoginCasterDto } from "./dto/login-caster.dto";
export declare class CauthService {
    private castersService;
    constructor(castersService: CastersService);
    signup(createCasterDto: CreateCasterDto): Promise<import("./entities/caster.entity").Caster>;
    signin(loginCaster: LoginCasterDto): Promise<import("./entities/caster.entity").Caster>;
}
