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
exports.CauthService = void 0;
const common_1 = require("@nestjs/common");
const casters_service_1 = require("./casters.service");
const crypto_1 = require("crypto");
const util_1 = require("util");
const scrypt = (0, util_1.promisify)(crypto_1.scrypt);
let CauthService = class CauthService {
    constructor(castersService) {
        this.castersService = castersService;
    }
    async signup(createCasterDto) {
        const casterByEmail = this.castersService.findByEmail(createCasterDto.email);
        if (!casterByEmail) {
            throw new common_1.BadRequestException('Email registered already');
        }
        const casterByGamerTag = this.castersService.findByGamerTag(createCasterDto.gamerTag);
        if (!casterByGamerTag) {
            throw new common_1.BadRequestException('Gamer tag in use');
        }
        const salt = (0, crypto_1.randomBytes)(128).toString('hex');
        const hash = (await scrypt(createCasterDto.password, salt, 32));
        const result = salt + '.' + hash.toString('hex');
        createCasterDto.password = result;
        const caster = await this.castersService.create(createCasterDto);
        return caster;
    }
    async signin(loginCaster) {
        const [caster] = await this.castersService.findByEmail(loginCaster.email);
        if (!caster) {
            throw new common_1.NotFoundException('User not found');
        }
        const [salt, storedHash] = caster.password.split('.');
        const hash = (await scrypt(loginCaster.password, salt, 32));
        if (storedHash !== hash.toString('hex')) {
            throw new common_1.BadRequestException('Authentication failed');
        }
        return caster;
    }
};
CauthService = __decorate([
    (0, common_1.Injectable)(),
    __metadata("design:paramtypes", [casters_service_1.CastersService])
], CauthService);
exports.CauthService = CauthService;
//# sourceMappingURL=cauth.service.js.map