import {
  Controller,
  Get,
  Post,
  Body,
  Patch,
  Param,
  Delete,
  UseGuards,
  UseInterceptors,
  Session,
  NotFoundException
} from '@nestjs/common';
import { OrganisationsService } from './organisations.service';
import { CreateOrganisationDto } from './dto/create-organisation.dto';
import { UpdateOrganisationDto } from './dto/update-organisation.dto';
import {OauthService} from "./oauth.service";
import {AuthGuard} from "../guards/auth.guard";
import {Organisation} from "./entities/organisation.entity";
import {CurrentOrganisation} from "./current-organisation.decorator";
import {Serialize} from "../interceptors/serialize.interceptor";
import {OrganisationDto} from "./dto/organisation.dto";
import {CurrentOrganisationInterceptor} from "./interceptors/current-organisation.interceptor";
import {LoginOrganisationDto} from "./dto/login-organisation.dto";

@Serialize(OrganisationDto)
@Controller('organisations')
@UseInterceptors(CurrentOrganisationInterceptor)
export class OrganisationsController {
  constructor(
      private readonly organisationsService: OrganisationsService,
      private readonly authService: OauthService) {}

  @Get('/currentorganisation')
  @UseGuards(AuthGuard)
  getCurrentOrganisation(@CurrentOrganisation() organisation: Organisation){
    return organisation;
  }

  @Post('/signup')
  async create(@Body() createOrganisationDto: CreateOrganisationDto, @Session() session: any) {
    const organisation = await this.authService.signup(createOrganisationDto);
    session.organisationId = organisation.id;
    return organisation;
  }

  @Post('/signin')
  async signin(@Body() loginOrganisationDto: LoginOrganisationDto, @Session() session: any){
    const organisation = await this.authService.signin(loginOrganisationDto);
    session.organisationId = organisation.id;
    return organisation;
  }

  @Post('/signout')
  singout(@Session() session: any){
    session.organisationId = null;
  }

  @Get()
  findAll() {
    return this.organisationsService.findAll();
  }

  @Get(':id')
  async findOne(@Param('id') id: string) {
    const organisation = await this.organisationsService.findOne(+id);
    if(!organisation){
      throw new NotFoundException('Organisation not found')
    }
    return organisation;
  }

  @Patch(':id')
  update(@Param('id') id: string, @Body() updateOrganisationDto: UpdateOrganisationDto) {
    return this.organisationsService.update(+id, updateOrganisationDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.organisationsService.remove(+id);
  }
}
