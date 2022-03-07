import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { CastersModule } from './casters/casters.module';
import { OrganisationsModule } from './organisations/organisations.module';

@Module({
  imports: [CastersModule, OrganisationsModule],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
