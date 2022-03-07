import { PartialType } from '@nestjs/mapped-types';
import { CreateCasterDto } from './create-caster.dto';

export class UpdateCasterDto extends PartialType(CreateCasterDto) {}
