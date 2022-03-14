import {User} from "../../Shared/Entities/user.entity";
import { Entity, Column } from "typeorm";

@Entity()
export class Organisation extends User {

    @Column()
    website: string;

}
