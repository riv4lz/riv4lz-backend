import { NestInterceptor, ExecutionContext, CallHandler } from "@nestjs/common";
import { OrganisationsService } from "../organisations.service";
export declare class CurrentOrganisationInterceptor implements NestInterceptor {
    private organisationService;
    constructor(organisationService: OrganisationsService);
    intercept(context: ExecutionContext, handler: CallHandler): Promise<import("rxjs").Observable<any>>;
}
