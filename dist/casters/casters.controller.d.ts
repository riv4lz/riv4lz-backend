import { CastersService } from './casters.service';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { CauthService } from "./cauth.service";
import { LoginCasterDto } from "./dto/login-caster.dto";
import { Caster } from "./entities/caster.entity";
export declare class CastersController {
    private readonly castersService;
    private readonly authService;
    constructor(castersService: CastersService, authService: CauthService);
    getCurrentUser(caster: Caster): Caster;
    create(createCasterDto: CreateCasterDto, session: any): Promise<Caster>;
    signin(loginCasterDto: LoginCasterDto, session: any): Promise<Caster>;
    signOut(session: any): void;
    findAll(): Promise<Caster[]>;
    findOne(id: string): Promise<Caster>;
    update(id: string, updateCasterDto: UpdateCasterDto): Promise<Caster>;
    remove(id: string): Promise<Caster>;
}
