"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.OrganisationsService = void 0;
const common_1 = require("@nestjs/common");
let OrganisationsService = class OrganisationsService {
    create(createOrganisationDto) {
        return 'This action adds a new organisation';
    }
    findAll() {
        return `This action returns all organisations`;
    }
    findOne(id) {
        return `This action returns a #${id} organisation`;
    }
    update(id, updateOrganisationDto) {
        return `This action updates a #${id} organisation`;
    }
    remove(id) {
        return `This action removes a #${id} organisation`;
    }
};
OrganisationsService = __decorate([
    (0, common_1.Injectable)()
], OrganisationsService);
exports.OrganisationsService = OrganisationsService;
//# sourceMappingURL=organisations.service.js.map