import { Injectable } from '@nestjs/common';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';

@Injectable()
export class CastersService {
  create(createCasterDto: CreateCasterDto) {
    return 'This action adds a new caster';
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
