import { Expose, Exclude } from "class-transformer";

export class OrganisationDto {
    @Expose()
    id: number;

    @Expose()
    email: string;

    @Expose()
    website: string;

    // TODO remove this
    @Expose()
    password: string;

}
