import {Controller, Get, Post, Body, Patch, Param, Delete, NotFoundException, UseInterceptors, ClassSerializerInterceptor, Session, UseGuards} from '@nestjs/common';
import { CastersService } from './casters.service';
import { CreateCasterDto } from './dto/create-caster.dto';
import { UpdateCasterDto } from './dto/update-caster.dto';
import { Serialize} from "../interceptors/serialize.interceptor";
import { CasterDto } from "./dto/caster.dto";
import { CauthService } from "./cauth.service";
import { LoginCasterDto } from "./dto/login-caster.dto";
import { CurrentCaster } from "./current-caster.decorator";
import { CurrentCasterInterceptor } from "../interceptors/current-caster.interceptor";
import {Caster} from "./entities/caster.entity";
import {AuthGuard} from "../guards/auth.guard";

@Serialize(CasterDto)
@Controller('casters')
@UseInterceptors(CurrentCasterInterceptor)
export class CastersController {
  constructor(
      private readonly castersService: CastersService,
      private readonly authService: CauthService) {}

  @Get('/currentcaster')
  @UseGuards(AuthGuard)
  getCurrentUser(@CurrentCaster() caster: Caster){

    return caster;
  }

  @Post('/signup')
  async create(@Body() createCasterDto: CreateCasterDto, @Session() session: any) {
    const caster = await this.authService.signup(createCasterDto);
    session.casterId = caster.id;
    return caster;
  }

  @Post('/signin')
  async signin(@Body() loginCasterDto: LoginCasterDto, @Session() session: any){
    const caster = await this.authService.signin(loginCasterDto);
    session.casterId = caster.id;
    return caster;
  }

  @Post('/signout')
  signOut(@Session() session: any){
    session.casterId = null;
  }

  @Get()
  findAll() {
    return this.castersService.findAll();
  }

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
