import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
import { Organisation } from "./entities/organisation.entity";
import { Repository } from "typeorm";
export declare class OrganisationsService {
    private repo;
    constructor(repo: Repository<Organisation>);
    create(createOrganisationDto: CreateOrganisationDto): Promise<Organisation>;
    findAll(): Promise<Organisation[]>;
    findOne(id: number): Promise<Organisation>;
    findByEmail(email: string): Promise<Organisation[]>;
    update(id: number, updateOrganisationDto: UpdateOrganisationDto): Promise<Organisation>;
    remove(id: number): Promise<Organisation>;
}
