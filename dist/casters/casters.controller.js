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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.CastersController = void 0;
const common_1 = require("@nestjs/common");
const casters_service_1 = require("./casters.service");
const create_caster_dto_1 = require("./dto/create-caster.dto");
const update_caster_dto_1 = require("./dto/update-caster.dto");
const swagger_1 = require("@nestjs/swagger");
const create_organisation_dto_1 = require("../organisations/dto/create-organisation.dto");
const serialize_interceptor_1 = require("../interceptors/serialize.interceptor");
const caster_dto_1 = require("./dto/caster.dto");
const auth_service_1 = require("./auth.service");
const login_caster_dto_1 = require("./dto/login-caster.dto");
let CastersController = class CastersController {
    constructor(castersService, authService) {
        this.castersService = castersService;
        this.authService = authService;
    }
    create(createCasterDto) {
        return this.authService.signup(createCasterDto);
    }
    signin(loginCasterDto) {
        return this.authService.signin(loginCasterDto);
    }
    findAll() {
        return this.castersService.findAll();
    }
    async findOne(id) {
        const user = await this.castersService.findOne(+id);
        if (!user) {
            throw new common_1.NotFoundException('User not found');
        }
        return user;
    }
    update(id, updateCasterDto) {
        return this.castersService.update(+id, updateCasterDto);
    }
    remove(id) {
        return this.castersService.remove(+id);
    }
};
__decorate([
    (0, common_1.Post)('/signup'),
    __param(0, (0, common_1.Body)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [create_caster_dto_1.CreateCasterDto]),
    __metadata("design:returntype", void 0)
], CastersController.prototype, "create", null);
__decorate([
    (0, common_1.Post)('/signup'),
    __param(0, (0, common_1.Body)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [login_caster_dto_1.LoginCasterDto]),
    __metadata("design:returntype", void 0)
], CastersController.prototype, "signin", null);
__decorate([
    (0, common_1.Get)(),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], CastersController.prototype, "findAll", null);
__decorate([
    (0, common_1.Get)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String]),
    __metadata("design:returntype", Promise)
], CastersController.prototype, "findOne", null);
__decorate([
    (0, common_1.Patch)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __param(1, (0, common_1.Body)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String, update_caster_dto_1.UpdateCasterDto]),
    __metadata("design:returntype", void 0)
], CastersController.prototype, "update", null);
__decorate([
    (0, common_1.Delete)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String]),
    __metadata("design:returntype", void 0)
], CastersController.prototype, "remove", null);
CastersController = __decorate([
    (0, serialize_interceptor_1.Serialize)(caster_dto_1.CasterDto),
    (0, swagger_1.ApiExtraModels)(create_caster_dto_1.CreateCasterDto, create_organisation_dto_1.CreateOrganisationDto),
    (0, common_1.Controller)('cauth'),
    __metadata("design:paramtypes", [casters_service_1.CastersService,
        auth_service_1.AuthService])
], CastersController);
exports.CastersController = CastersController;
//# sourceMappingURL=casters.controller.js.map