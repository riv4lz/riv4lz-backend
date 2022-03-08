import { Module } from '@nestjs/common';
import { TypeOrmModule} from "@nestjs/typeorm";
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { CastersModule } from './casters/casters.module';
import { OrganisationsModule } from './organisations/organisations.module';
import {Caster} from "./casters/entities/caster.entity";
import { User } from "./Shared/Entities/user.entity";
import {Organisation} from "./organisations/entities/organisation.entity";

@Module({
  imports: [TypeOrmModule.forRoot({
    type: 'sqlite',
    database: 'db.sqlite',
    entities: [User, Caster, Organisation],
    synchronize: true,
  }),
    CastersModule,
    OrganisationsModule,],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
