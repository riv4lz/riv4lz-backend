import { Injectable } from '@nestjs/common';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { Repository } from "typeorm";
import { InjectRepository } from "@nestjs/typeorm";
import { Caster } from "./entities/caster.entity";


@Injectable()
export class CastersService {

  constructor(
      @InjectRepository(Caster)
      private repo: Repository<Caster>) {
  }

  create(createCasterDto: CreateCasterDto) {
    const user = this.repo.create(createCasterDto);
    return this.repo.save(user);
  }

  findAll() {
    return `This action returns all casters`;
  }

  findOne(id: number) {
    return `This action returns a #${id} caster`;
  }

  update(id: number, updateCasterDto: UpdateCasterDto) {
    return `This action updates a #${id} caster`;
  }

  remove(id: number) {
    return `This action removes a #${id} caster`;
  }
}
