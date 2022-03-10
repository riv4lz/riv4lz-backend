"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CurrentCaster = void 0;
const common_1 = require("@nestjs/common");
exports.CurrentCaster = (0, common_1.createParamDecorator)((data, context) => {
    const request = context.switchToHttp().getRequest();
    return request.currentCaster;
});
//# sourceMappingURL=current-caster.decorator.js.map