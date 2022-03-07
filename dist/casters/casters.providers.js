"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.castersProviders = void 0;
const caster_entity_1 = require("./entities/caster.entity");
exports.castersProviders = [
    {
        provide: 'CASTERS_REPOSITORY',
        useFactory: (connection) => connection.getRepository(caster_entity_1.Caster),
        inject: ['DATABASE_CONNECTION'],
    }
];
//# sourceMappingURL=casters.providers.js.map