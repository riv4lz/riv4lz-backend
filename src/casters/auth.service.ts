import {BadRequestException, Injectable} from "@nestjs/common";
import { CastersService } from "./casters.service";
import { randomBytes, scrypt as _scrypt } from "crypto";
import { promisify } from "util";
import { CreateCasterDto } from "./dto/create-caster.dto";

const scrypt = promisify(_scrypt);

@Injectable()
export class AuthService{
    constructor(private castersService: CastersService) {
    }

    async signup(createCasterDto: CreateCasterDto){
        const casterByEmail = this.castersService.findByEmail(createCasterDto.email);
        if(!casterByEmail){
            throw new BadRequestException('Email registered already')
        }

        const casterByGamerTag = this.castersService.findByGamerTag(createCasterDto.gamerTag);
        if(!casterByGamerTag){
            throw new BadRequestException('Gamer tag in use');
        }

        const salt = randomBytes(128).toString('hex');
        const hash = (await scrypt(createCasterDto.password, salt, 32)) as Buffer;
        const result = salt + '.' + hash.toString('hex');
        createCasterDto.password = result;

        const caster = await this.castersService.create(createCasterDto);
        return caster;
    }

    singin(){

    }
}
