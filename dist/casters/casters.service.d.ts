import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { Repository } from "typeorm";
import { Caster } from "./entities/caster.entity";
export declare class CastersService {
    private repo;
    constructor(repo: Repository<Caster>);
    create(createCasterDto: CreateCasterDto): Promise<Caster>;
    findAll(): string;
    findOne(id: number): string;
    update(id: number, updateCasterDto: UpdateCasterDto): string;
    remove(id: number): string;
}
