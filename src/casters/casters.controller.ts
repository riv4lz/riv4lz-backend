import {Controller, Get, Post, Body, Patch, Param, Delete, NotFoundException, UseInterceptors, ClassSerializerInterceptor} from '@nestjs/common';
import { CastersService } from './casters.service';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import {ApiExtraModels} from "@nestjs/swagger";
import {CreateOrganisationDto} from "../organisations/dto/create-organisation.dto";
import { SerializeInterceptor} from "../interceptors/serialize.interceptor";
import { LoginCasterDto } from "./dto/login-caster.dto";

@ApiExtraModels(CreateCasterDto, CreateOrganisationDto)
@Controller('cauth')
export class CastersController {
  constructor(private readonly castersService: CastersService) {}

  @Post('/signup')
  create(@Body() createCasterDto: CreateCasterDto) {
    return this.castersService.create(createCasterDto);
  }
  
  @Get()
  findAll() {
    return this.castersService.findAll();
  }

  @UseInterceptors(new SerializeInterceptor(LoginCasterDto))
  @Get(':id')
  async findOne(@Param('id') id: string) {
    const user = await this.castersService.findOne(+id);
    if (!user) {
      throw new NotFoundException('User not found');
    }
    return user;
  }

  @Patch(':id')
  update(@Param('id') id: string, @Body() updateCasterDto: UpdateCasterDto) {
    return this.castersService.update(+id, updateCasterDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.castersService.remove(+id);
  }
}
