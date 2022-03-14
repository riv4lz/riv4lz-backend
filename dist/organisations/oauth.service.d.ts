import { CreateOrganisationDto } from "../organisations/dto/create-organisation.dto";
import { OrganisationsService } from "./organisations.service";
import { LoginOrganisationDto } from "./dto/login-organisation.dto";
export declare class OauthService {
    private organisationsService;
    constructor(organisationsService: OrganisationsService);
    signup(createOrganisationDto: CreateOrganisationDto): Promise<import("./entities/organisation.entity").Organisation>;
    signin(loginOrganisationDto: LoginOrganisationDto): Promise<import("./entities/organisation.entity").Organisation>;
}
