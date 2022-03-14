import {Injectable, NotFoundException} from '@nestjs/common';
import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
import {InjectRepository} from "@nestjs/typeorm";
import {Organisation} from "./entities/organisation.entity";
import {Repository} from "typeorm";

@Injectable()
export class OrganisationsService {
  constructor(
      @InjectRepository(Organisation)
      private repo: Repository<Organisation>) {
  }

  create(createOrganisationDto: CreateOrganisationDto) {
    const organisation = this.repo.create(createOrganisationDto);
    return this.repo.save(organisation);
  }

  findAll() {
    return this.repo.find();
  }

  findOne(id: number) {
    if (!id){
      throw new NotFoundException('No user signed in');
    }
    return this.repo.findOne(id);
  }

  findByEmail(email: string){
    return this.repo.find({email})
  }

  async update(id: number, updateOrganisationDto: UpdateOrganisationDto) {
    const user = await this.findOne(id);
    if(!user){
      throw new NotFoundException('User not found');
    }
    Object.assign(user, updateOrganisationDto);
    return this.repo.save(user);
  }



  async remove(id: number) {
    const user = await this.findOne(id);
    if(!user){
      throw new NotFoundException('User not found')
    }
    return this.repo.remove(user);
  }
}
