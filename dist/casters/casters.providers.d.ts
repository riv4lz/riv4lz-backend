import { Connection } from "typeorm";
import { Caster } from './entities/caster.entity';
export declare const castersProviders: {
    provide: string;
    useFactory: (connection: Connection) => import("typeorm").Repository<Caster>;
    inject: string[];
}[];
