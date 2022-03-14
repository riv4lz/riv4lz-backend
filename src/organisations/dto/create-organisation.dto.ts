import {IsEmail, IsString } from "class-validator";
import {ApiProperty} from "@nestjs/swagger";

export class CreateOrganisationDto {
    @ApiProperty()
    @IsEmail()
    email: string;

    @ApiProperty()
    @IsString()
    password: string;

    @ApiProperty()
    @IsString()
    website: string;
}
