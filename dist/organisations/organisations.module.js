"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrganisationsModule = void 0;
const common_1 = require("@nestjs/common");
const organisations_service_1 = require("./organisations.service");
const organisations_controller_1 = require("./organisations.controller");
const typeorm_1 = require("@nestjs/typeorm");
const organisation_entity_1 = require("./entities/organisation.entity");
const oauth_service_1 = require("./oauth.service");
let OrganisationsModule = class OrganisationsModule {
};
OrganisationsModule = __decorate([
    (0, common_1.Module)({
        imports: [typeorm_1.TypeOrmModule.forFeature([organisation_entity_1.Organisation])],
        controllers: [organisations_controller_1.OrganisationsController],
        providers: [organisations_service_1.OrganisationsService, oauth_service_1.OauthService]
    })
], OrganisationsModule);
exports.OrganisationsModule = OrganisationsModule;
//# sourceMappingURL=organisations.module.js.map