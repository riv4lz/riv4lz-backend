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
exports.CurrentCasterInterceptor = void 0;
const common_1 = require("@nestjs/common");
const casters_service_1 = require("../casters/casters.service");
let CurrentCasterInterceptor = class CurrentCasterInterceptor {
    constructor(casterService) {
        this.casterService = casterService;
    }
    async intercept(context, handler) {
        const request = context.switchToHttp().getRequest();
        const casterId = request.session.casterId || {};
        if (casterId) {
            const caster = await this.casterService.findOne(casterId);
            request.currentCaster = caster;
        }
        return handler.handle();
    }
};
CurrentCasterInterceptor = __decorate([
    (0, common_1.Injectable)(),
    __metadata("design:paramtypes", [casters_service_1.CastersService])
], CurrentCasterInterceptor);
exports.CurrentCasterInterceptor = CurrentCasterInterceptor;
//# sourceMappingURL=current-caster.interceptor.js.map