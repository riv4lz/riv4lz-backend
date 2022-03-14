"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.CastersModule = void 0;
const common_1 = require("@nestjs/common");
const casters_service_1 = require("./casters.service");
const casters_controller_1 = require("./casters.controller");
const typeorm_1 = require("@nestjs/typeorm");
const caster_entity_1 = require("./entities/caster.entity");
const cauth_service_1 = require("./cauth.service");
const current_caster_interceptor_1 = require("../interceptors/current-caster.interceptor");
let CastersModule = class CastersModule {
};
CastersModule = __decorate([
    (0, common_1.Module)({
        imports: [typeorm_1.TypeOrmModule.forFeature([caster_entity_1.Caster])],
        controllers: [casters_controller_1.CastersController],
        providers: [casters_service_1.CastersService, cauth_service_1.CauthService, current_caster_interceptor_1.CurrentCasterInterceptor]
    })
], CastersModule);
exports.CastersModule = CastersModule;
//# sourceMappingURL=casters.module.js.map