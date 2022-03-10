import { NestInterceptor, ExecutionContext, CallHandler } from "@nestjs/common";
import { CastersService } from "../casters/casters.service";
export declare class CurrentCasterInterceptor implements NestInterceptor {
    private casterService;
    constructor(casterService: CastersService);
    intercept(context: ExecutionContext, handler: CallHandler): Promise<import("rxjs").Observable<any>>;
}
