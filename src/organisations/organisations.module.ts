import { Module } from '@nestjs/common';
import { OrganisationsService } from './organisations.service';
import { OrganisationsController } from './organisations.controller';
import {TypeOrmModule} from "@nestjs/typeorm";
import {Organisation} from "./entities/organisation.entity";
import {OauthService} from "./oauth.service";

@Module({
  imports: [TypeOrmModule.forFeature([Organisation])],
  controllers: [OrganisationsController],
  providers: [OrganisationsService, OauthService]
})
export class OrganisationsModule {}
