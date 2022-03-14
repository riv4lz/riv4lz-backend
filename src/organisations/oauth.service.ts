import {BadRequestException, Injectable, NotFoundException} from "@nestjs/common";
import { randomBytes, scrypt as _scrypt } from "crypto";
import { promisify } from "util";
import {CreateOrganisationDto} from "../organisations/dto/create-organisation.dto";
import {OrganisationsService} from "./organisations.service";
import {LoginOrganisationDto} from "./dto/login-organisation.dto";

const scrypt = promisify(_scrypt);

@Injectable()
export class OauthService {
    constructor(
        private organisationsService: OrganisationsService) {}

    async signup(createOrganisationDto: CreateOrganisationDto){
        const orgByEmail = this.organisationsService.findByEmail(createOrganisationDto.email);

        if(!orgByEmail){
            throw new BadRequestException('Email registered already')
        }

        const salt = randomBytes(128).toString('hex');
        const hash = (await scrypt(createOrganisationDto.password, salt, 32)) as Buffer;
        const result = salt + '.' + hash.toString('hex');
        createOrganisationDto.password = result;

        const caster = await this.organisationsService.create(createOrganisationDto);
        return caster;
    }

    async signin(loginOrganisationDto: LoginOrganisationDto){
        const [organisation] = await this.organisationsService.findByEmail(loginOrganisationDto.email);
        if(organisation){
            throw new NotFoundException('User not found');
        }

        const [salt, storedHash] = organisation.password.split('.');
        const hash = (await scrypt(loginOrganisationDto.password, salt, 32)) as Buffer;

        if(storedHash !== hash.toString('hex')) {
            throw new BadRequestException('Authentication failed');
        }

        return organisation;
    }

}
