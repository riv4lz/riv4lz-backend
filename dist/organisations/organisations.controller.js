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
exports.OrganisationsController = void 0;
const common_1 = require("@nestjs/common");
const organisations_service_1 = require("./organisations.service");
const create_organisation_dto_1 = require("./dto/create-organisation.dto");
const update_organisation_dto_1 = require("./dto/update-organisation.dto");
const oauth_service_1 = require("./oauth.service");
const auth_guard_1 = require("../guards/auth.guard");
const organisation_entity_1 = require("./entities/organisation.entity");
const current_organisation_decorator_1 = require("./current-organisation.decorator");
const serialize_interceptor_1 = require("../interceptors/serialize.interceptor");
const organisation_dto_1 = require("./dto/organisation.dto");
const current_organisation_interceptor_1 = require("./interceptors/current-organisation.interceptor");
const login_organisation_dto_1 = require("./dto/login-organisation.dto");
let OrganisationsController = class OrganisationsController {
    constructor(organisationsService, authService) {
        this.organisationsService = organisationsService;
        this.authService = authService;
    }
    getCurrentOrganisation(organisation) {
        return organisation;
    }
    async create(createOrganisationDto, session) {
        const organisation = await this.authService.signup(createOrganisationDto);
        session.organisationId = organisation.id;
        return organisation;
    }
    async signin(loginOrganisationDto, session) {
        const organisation = await this.authService.signin(loginOrganisationDto);
        session.organisationId = organisation.id;
        return organisation;
    }
    singout(session) {
        session.organisationId = null;
    }
    findAll() {
        return this.organisationsService.findAll();
    }
    async findOne(id) {
        const organisation = await this.organisationsService.findOne(+id);
        if (!organisation) {
            throw new common_1.NotFoundException('Organisation not found');
        }
        return organisation;
    }
    update(id, updateOrganisationDto) {
        return this.organisationsService.update(+id, updateOrganisationDto);
    }
    remove(id) {
        return this.organisationsService.remove(+id);
    }
};
__decorate([
    (0, common_1.Get)('/currentorganisation'),
    (0, common_1.UseGuards)(auth_guard_1.AuthGuard),
    __param(0, (0, current_organisation_decorator_1.CurrentOrganisation)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [organisation_entity_1.Organisation]),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "getCurrentOrganisation", null);
__decorate([
    (0, common_1.Post)('/signup'),
    __param(0, (0, common_1.Body)()),
    __param(1, (0, common_1.Session)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [create_organisation_dto_1.CreateOrganisationDto, Object]),
    __metadata("design:returntype", Promise)
], OrganisationsController.prototype, "create", null);
__decorate([
    (0, common_1.Post)('/signin'),
    __param(0, (0, common_1.Body)()),
    __param(1, (0, common_1.Session)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [login_organisation_dto_1.LoginOrganisationDto, Object]),
    __metadata("design:returntype", Promise)
], OrganisationsController.prototype, "signin", null);
__decorate([
    (0, common_1.Post)('/signout'),
    __param(0, (0, common_1.Session)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Object]),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "singout", null);
__decorate([
    (0, common_1.Get)(),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "findAll", null);
__decorate([
    (0, common_1.Get)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String]),
    __metadata("design:returntype", Promise)
], OrganisationsController.prototype, "findOne", null);
__decorate([
    (0, common_1.Patch)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __param(1, (0, common_1.Body)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String, update_organisation_dto_1.UpdateOrganisationDto]),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "update", null);
__decorate([
    (0, common_1.Delete)(':id'),
    __param(0, (0, common_1.Param)('id')),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [String]),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "remove", null);
OrganisationsController = __decorate([
    (0, serialize_interceptor_1.Serialize)(organisation_dto_1.OrganisationDto),
    (0, common_1.Controller)('organisations'),
    (0, common_1.UseInterceptors)(current_organisation_interceptor_1.CurrentOrganisationInterceptor),
    __metadata("design:paramtypes", [organisations_service_1.OrganisationsService,
        oauth_service_1.OauthService])
], OrganisationsController);
exports.OrganisationsController = OrganisationsController;
//# sourceMappingURL=organisations.controller.js.map