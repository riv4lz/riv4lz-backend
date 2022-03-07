import { Module } from '@nestjs/common';
import { CastersService } from './casters.service';
import { CastersController } from './casters.controller';

@Module({
  controllers: [CastersController],
  providers: [CastersService]
})
export class CastersModule {}
