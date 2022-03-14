import { OrganisationsService } from './organisations.service';
import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
import { OauthService } from "./oauth.service";
import { Organisation } from "./entities/organisation.entity";
import { LoginOrganisationDto } from "./dto/login-organisation.dto";
export declare class OrganisationsController {
    private readonly organisationsService;
    private readonly authService;
    constructor(organisationsService: OrganisationsService, authService: OauthService);
    getCurrentOrganisation(organisation: Organisation): Organisation;
    create(createOrganisationDto: CreateOrganisationDto, session: any): Promise<Organisation>;
    signin(loginOrganisationDto: LoginOrganisationDto, session: any): Promise<Organisation>;
    singout(session: any): void;
    findAll(): Promise<Organisation[]>;
    findOne(id: string): Promise<Organisation>;
    update(id: string, updateOrganisationDto: UpdateOrganisationDto): Promise<Organisation>;
    remove(id: string): Promise<Organisation>;
}
