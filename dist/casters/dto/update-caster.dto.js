"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UpdateCasterDto = void 0;
const mapped_types_1 = require("@nestjs/mapped-types");
const create_caster_dto_1 = require("./create-caster.dto");
class UpdateCasterDto extends (0, mapped_types_1.PartialType)(create_caster_dto_1.CreateCasterDto) {
}
exports.UpdateCasterDto = UpdateCasterDto;
//# sourceMappingURL=update-caster.dto.js.map