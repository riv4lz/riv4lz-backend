import { Column, Entity, ManyToOne, PrimaryGeneratedColumn } from 'typeorm';

import {Caster} from "../../casters/entities/caster.entity";

@Entity()
class Message {
    @PrimaryGeneratedColumn()
    public id: number;

    @Column()
    public content: string;

}

export default Message;
