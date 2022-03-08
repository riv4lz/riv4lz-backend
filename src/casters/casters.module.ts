import { Module } from '@nestjs/common';
import { CastersService } from './casters.service';
import { CastersController } from './casters.controller';
import { TypeOrmModule } from "@nestjs/typeorm";
import { Caster } from "./entities/caster.entity";

@Module({
  imports: [TypeOrmModule.forFeature([Caster])],
  controllers: [CastersController],
  providers: [CastersService]
})
export class CastersModule {}
