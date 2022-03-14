"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.OauthService = void 0;
const common_1 = require("@nestjs/common");
const crypto_1 = require("crypto");
const util_1 = require("util");
const organisations_service_1 = require("./organisations.service");
const scrypt = (0, util_1.promisify)(crypto_1.scrypt);
let OauthService = class OauthService {
    constructor(organisationsService) {
        this.organisationsService = organisationsService;
    }
    async signup(createOrganisationDto) {
        const orgByEmail = this.organisationsService.findByEmail(createOrganisationDto.email);
        if (!orgByEmail) {
            throw new common_1.BadRequestException('Email registered already');
        }
        const salt = (0, crypto_1.randomBytes)(128).toString('hex');
        const hash = (await scrypt(createOrganisationDto.password, salt, 32));
        const result = salt + '.' + hash.toString('hex');
        createOrganisationDto.password = result;
        const caster = await this.organisationsService.create(createOrganisationDto);
        return caster;
    }
    async signin(loginOrganisationDto) {
        const [organisation] = await this.organisationsService.findByEmail(loginOrganisationDto.email);
        if (organisation) {
            throw new common_1.NotFoundException('User not found');
        }
        const [salt, storedHash] = organisation.password.split('.');
        const hash = (await scrypt(loginOrganisationDto.password, salt, 32));
        if (storedHash !== hash.toString('hex')) {
            throw new common_1.BadRequestException('Authentication failed');
        }
        return organisation;
    }
};
OauthService = __decorate([
    (0, common_1.Injectable)(),
    __metadata("design:paramtypes", [organisations_service_1.OrganisationsService])
], OauthService);
exports.OauthService = OauthService;
//# sourceMappingURL=oauth.service.js.map