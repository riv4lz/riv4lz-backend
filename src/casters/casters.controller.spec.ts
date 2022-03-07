import { Test, TestingModule } from '@nestjs/testing';
import { CastersController } from './casters.controller';
import { CastersService } from './casters.service';

describe('CastersController', () => {
  let controller: CastersController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [CastersController],
      providers: [CastersService],
    }).compile();

    controller = module.get<CastersController>(CastersController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
