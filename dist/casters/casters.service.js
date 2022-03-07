"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.CastersService = void 0;
const common_1 = require("@nestjs/common");
let CastersService = class CastersService {
    create(createCasterDto) {
        return 'This action adds a new caster';
    }
    findAll() {
        return `This action returns all casters`;
    }
    findOne(id) {
        return `This action returns a #${id} caster`;
    }
    update(id, updateCasterDto) {
        return `This action updates a #${id} caster`;
    }
    remove(id) {
        return `This action removes a #${id} caster`;
    }
};
CastersService = __decorate([
    (0, common_1.Injectable)()
], CastersService);
exports.CastersService = CastersService;
//# sourceMappingURL=casters.service.js.map