import { Module } from '@nestjs/common';
import { TypeOrmModule} from "@nestjs/typeorm";
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { CastersModule } from './casters/casters.module';
import { OrganisationsModule } from './organisations/organisations.module';
import {Caster} from "./casters/entities/caster.entity";

@Module({
  imports: [TypeOrmModule.forRoot({
    type: 'sqlite',
    database: 'db.sqlite',
    entities: [],
    synchronize: true,
  }),
    CastersModule,
    OrganisationsModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
