import { OrganisationsService } from './organisations.service';
import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
export declare class OrganisationsController {
    private readonly organisationsService;
    constructor(organisationsService: OrganisationsService);
    create(createOrganisationDto: CreateOrganisationDto): string;
    findAll(): string;
    findOne(id: string): string;
    update(id: string, updateOrganisationDto: UpdateOrganisationDto): string;
    remove(id: string): string;
}
