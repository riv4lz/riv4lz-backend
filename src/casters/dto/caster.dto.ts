import { Expose, Exclude } from "class-transformer";

export class CasterDto {
    @Expose()
    id: number;

    @Expose()
    email: string;

    @Expose()
    gamerTag: string;

    // TODO remove this
    @Expose()
    password: string;

}
