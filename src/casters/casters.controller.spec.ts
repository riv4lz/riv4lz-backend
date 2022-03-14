import { CastersService } from "./casters.service";
import {CastersController} from "./casters.controller";
import {before} from "@nestjs/swagger/dist/plugin";
import {Test} from "@nestjs/testing";
import {Caster} from "./entities/caster.entity";

describe('CastersController', () => {
    let castersController: CastersController;
    let castersService: CastersService;

    beforeEach(async () => {
        const moduleRef = await Test.createTestingModule({
            controllers: [CastersController],
            providers: [CastersService],
        }).compile();

        castersService = moduleRef.get<CastersService>(CastersService);
        castersController = moduleRef.get<CastersController>(CastersController);
    });
    
    describe('findAll', () => {
        it('should return an array of all casters', async () => {
            const caster = new Caster()
            const result = [caster];
            jest.spyOn(castersService, 'findAll').mockImplementation(() => new Promise((resolve, reject) => resolve(result)));

            expect(await castersController.findAll()).toBe(result);
        });
    })
})
