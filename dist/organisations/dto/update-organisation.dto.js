"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UpdateOrganisationDto = void 0;
const mapped_types_1 = require("@nestjs/mapped-types");
const create_organisation_dto_1 = require("./create-organisation.dto");
class UpdateOrganisationDto extends (0, mapped_types_1.PartialType)(create_organisation_dto_1.CreateOrganisationDto) {
}
exports.UpdateOrganisationDto = UpdateOrganisationDto;
//# sourceMappingURL=update-organisation.dto.js.map