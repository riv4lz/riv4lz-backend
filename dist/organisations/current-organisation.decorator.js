"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CurrentOrganisation = void 0;
const common_1 = require("@nestjs/common");
exports.CurrentOrganisation = (0, common_1.createParamDecorator)((data, context) => {
    const request = context.switchToHttp().getRequest();
    return request.currentOrganisation;
});
//# sourceMappingURL=current-organisation.decorator.js.map