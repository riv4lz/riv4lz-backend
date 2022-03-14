import {
    NestInterceptor,
    ExecutionContext,
    CallHandler,
    Injectable } from "@nestjs/common";
import { CastersService } from "../casters/casters.service";


@Injectable()
export  class CurrentCasterInterceptor implements NestInterceptor{
    constructor(private casterService: CastersService){}


    async intercept(context: ExecutionContext, handler: CallHandler){
        const request = context.switchToHttp().getRequest();
        const casterId = request.session.casterId || {};
        if (casterId){
            const caster = await this.casterService.findOne(casterId);
            request.currentCaster = caster;
        }
        return handler.handle();
    }

}
