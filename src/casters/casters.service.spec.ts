import { Test, TestingModule } from '@nestjs/testing';
import { CastersService } from './casters.service';

describe('CastersService', () => {
  let service: CastersService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [CastersService],
    }).compile();

    service = module.get<CastersService>(CastersService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
