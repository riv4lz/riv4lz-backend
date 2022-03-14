import {GameEntity} from "../../Shared/Entities/game.entity";
import {Entity} from "typeorm";
import {Organisation} from "../../organisations/entities/organisation.entity";

@Entity()
export class Event {
    dateTime: Date;
    game: GameEntity;
    organisation: Organisation;
}
