import {IsEmail, IsString } from "class-validator";
import {ApiProperty} from "@nestjs/swagger";

export class CreateCasterDto {
    @ApiProperty()
    @IsEmail()
    email: string;

    @ApiProperty()
    @IsString()
    password: string;

    @ApiProperty()
    @IsString()
    gamerTag: string;
}
