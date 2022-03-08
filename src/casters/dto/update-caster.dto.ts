import { PartialType } from '@nestjs/mapped-types';
import { CreateCasterDto } from './create-caster.dto';
import {ApiProperty} from "@nestjs/swagger";
import {IsEmail, IsString} from "class-validator";

export class UpdateCasterDto extends PartialType(CreateCasterDto) {
    @ApiProperty()
    @IsEmail()
    newEmail: string;

    @ApiProperty()
    @IsString()
    newPassword: string;

    @ApiProperty()
    @IsString()
    newGamerTag: string;
}
