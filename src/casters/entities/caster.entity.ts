import {User} from "../../Shared/Entities/user.entity";
import { Entity, Column } from "typeorm";

@Entity()
export class Caster extends User {

    @Column()
    gamerTag: string;
}
