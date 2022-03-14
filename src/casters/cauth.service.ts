import {BadRequestException, Injectable, NotFoundException} from "@nestjs/common";
import { CastersService } from "./casters.service";
import { randomBytes, scrypt as _scrypt } from "crypto";
import { promisify } from "util";
import { CreateCasterDto } from "./dto/create-caster.dto";
import {LoginCasterDto} from "./dto/login-caster.dto";

const scrypt = promisify(_scrypt);

@Injectable()
export class CauthService {
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

    async signin(loginCaster: LoginCasterDto){
        const [caster] = await this.castersService.findByEmail(loginCaster.email);
        if(!caster){
            throw new NotFoundException('User not found');
        }

        const [salt, storedHash] = caster.password.split('.');
        const hash = (await scrypt(loginCaster.password, salt, 32)) as Buffer;

        if(storedHash !== hash.toString('hex')) {
            throw new BadRequestException('Authentication failed');
        }

        return caster;
    }
}
