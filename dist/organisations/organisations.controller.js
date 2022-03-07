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
let OrganisationsController = class OrganisationsController {
    constructor(organisationsService) {
        this.organisationsService = organisationsService;
    }
    create(createOrganisationDto) {
        return this.organisationsService.create(createOrganisationDto);
    }
    findAll() {
        return this.organisationsService.findAll();
    }
    findOne(id) {
        return this.organisationsService.findOne(+id);
    }
    update(id, updateOrganisationDto) {
        return this.organisationsService.update(+id, updateOrganisationDto);
    }
    remove(id) {
        return this.organisationsService.remove(+id);
    }
};
__decorate([
    (0, common_1.Post)(),
    __param(0, (0, common_1.Body)()),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [create_organisation_dto_1.CreateOrganisationDto]),
    __metadata("design:returntype", void 0)
], OrganisationsController.prototype, "create", null);
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
    __metadata("design:returntype", void 0)
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
    (0, common_1.Controller)('organisations'),
    __metadata("design:paramtypes", [organisations_service_1.OrganisationsService])
], OrganisationsController);
exports.OrganisationsController = OrganisationsController;
//# sourceMappingURL=organisations.controller.js.map