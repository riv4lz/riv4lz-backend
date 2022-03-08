import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
export declare class OrganisationsService {
    create(createOrganisationDto: CreateOrganisationDto): string;
    findAll(): string;
    findOne(id: number): string;
    update(id: number, updateOrganisationDto: UpdateOrganisationDto): string;
    remove(id: number): string;
}
