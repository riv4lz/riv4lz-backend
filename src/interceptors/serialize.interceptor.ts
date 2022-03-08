import { UseInterceptors, NestInterceptor, ExecutionContext, CallHandler} from "@nestjs/common";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators'
import { plainToInstance } from "class-transformer";
import { LoginCasterDto } from "../casters/dto/login-caster.dto";

export class SerializeInterceptor implements NestInterceptor{
    intercept(context: ExecutionContext, handler: CallHandler): Observable<any>{
        return handler.handle().pipe(
            map((data: any) => {
                return plainToInstance(LoginCasterDto, data, {
                    excludeExtraneousValues: true,
                });
            }),
        );
    }
}
