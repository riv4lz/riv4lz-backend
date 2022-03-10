import { Expose, Exclude } from "class-transformer";

export class LoginCasterDto{
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
