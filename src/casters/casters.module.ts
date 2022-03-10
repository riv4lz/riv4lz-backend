import { Module } from '@nestjs/common';
import { CastersService } from './casters.service';
import { CastersController } from './casters.controller';
import { TypeOrmModule } from "@nestjs/typeorm";
import { Caster } from "./entities/caster.entity";
import {AuthService} from "./auth.service";
import { CurrentCasterInterceptor } from "../interceptors/current-caster.interceptor";

@Module({
  imports: [TypeOrmModule.forFeature([Caster])],
  controllers: [CastersController],
  providers: [CastersService, AuthService, CurrentCasterInterceptor]
})
export class CastersModule {}
