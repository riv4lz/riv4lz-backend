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
exports.CastersService = void 0;
const common_1 = require("@nestjs/common");
const typeorm_1 = require("typeorm");
const typeorm_2 = require("@nestjs/typeorm");
const caster_entity_1 = require("./entities/caster.entity");
let CastersService = class CastersService {
    constructor(repo) {
        this.repo = repo;
    }
    create(createCasterDto) {
        const user = this.repo.create(createCasterDto);
        return this.repo.save(user);
    }
    findAll() {
        return this.repo.find();
    }
    findOne(id) {
        return this.repo.findOne(id);
    }
    update(id, updateCasterDto) {
        return `This action updates a #${id} caster`;
    }
    remove(id) {
        return `This action removes a #${id} caster`;
    }
};
CastersService = __decorate([
    (0, common_1.Injectable)(),
    __param(0, (0, typeorm_2.InjectRepository)(caster_entity_1.Caster)),
    __metadata("design:paramtypes", [typeorm_1.Repository])
], CastersService);
exports.CastersService = CastersService;
//# sourceMappingURL=casters.service.js.map