import { PartialType } from '@nestjs/mapped-types';
import { CreateCasterDto } from './create-caster.dto';
import {ApiProperty} from "@nestjs/swagger";
import {IsEmail, IsOptional, IsString} from "class-validator";

export class UpdateCasterDto extends PartialType(CreateCasterDto) {
    @ApiProperty()
    @IsOptional()
    @IsEmail()
    email: string;

    @ApiProperty()
    @IsOptional()
    @IsString()
    password: string;

    @ApiProperty()
    @IsOptional()
    @IsString()
    gamerTag: string;
}
