import {IsEmail, IsString } from "class-validator";
import {ApiProperty} from "@nestjs/swagger";

export class LoginOrganisationDto {
    @ApiProperty()
    @IsEmail()
    email: string;

    @ApiProperty()
    @IsString()
    password: string;
}
