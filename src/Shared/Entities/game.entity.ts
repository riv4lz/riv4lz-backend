import { Entity, Column, PrimaryGeneratedColumn } from "typeorm";

@Entity()
export class GameEntity{
    @PrimaryGeneratedColumn()
    id: number;

    @Column("uniqueidentifier")
    name: string;
}
