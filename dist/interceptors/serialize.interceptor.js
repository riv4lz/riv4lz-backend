"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SerializeInterceptor = void 0;
const operators_1 = require("rxjs/operators");
const class_transformer_1 = require("class-transformer");
const login_caster_dto_1 = require("../casters/dto/login-caster.dto");
class SerializeInterceptor {
    intercept(context, handler) {
        return handler.handle().pipe((0, operators_1.map)((data) => {
            return (0, class_transformer_1.plainToInstance)(login_caster_dto_1.LoginCasterDto, data, {
                excludeExtraneousValues: true,
            });
        }));
    }
}
exports.SerializeInterceptor = SerializeInterceptor;
//# sourceMappingURL=serialize.interceptor.js.map