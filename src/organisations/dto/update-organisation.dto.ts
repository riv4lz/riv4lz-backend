import { PartialType } from '@nestjs/mapped-types';
import { CreateOrganisationDto } from './create-organisation.dto';
import {ApiProperty} from "@nestjs/swagger";
import {IsEmail, IsOptional, IsString} from "class-validator";

export class UpdateOrganisationDto extends PartialType(CreateOrganisationDto) {
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
    website: string;
}
