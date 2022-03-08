import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { Repository } from "typeorm";
import { Caster } from "./entities/caster.entity";
export declare class CastersService {
    private repo;
    constructor(repo: Repository<Caster>);
    create(createCasterDto: CreateCasterDto): Promise<Caster>;
    findAll(): Promise<Caster[]>;
    findOne(id: number): Promise<Caster>;
    update(id: number, updateCasterDto: UpdateCasterDto): Promise<Caster>;
    remove(id: number): Promise<Caster>;
}
