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
    return this.repo.find();
  }

  findOne(id: number) {
    return this.repo.findOne(id);
  }

  async update(id: number, updateCasterDto: UpdateCasterDto) {
    const user = await this.findOne(id);
    if(!user){
      throw new Error('User not found');
    }
    Object.assign(user, updateCasterDto);
    return this.repo.save(user);
  }

  async remove(id: number) {
    const user = await this.findOne(id);
    if(!user){
      throw new Error('User not found')
    }
    return this.repo.remove(user);
  }
}
