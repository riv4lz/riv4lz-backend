import {
    NestInterceptor,
    ExecutionContext,
    CallHandler,
    Injectable } from "@nestjs/common";
import {OrganisationsService} from "../organisations.service";


@Injectable()
export class CurrentOrganisationInterceptor implements NestInterceptor{
    constructor(private organisationService: OrganisationsService) {
    }

    async intercept(context: ExecutionContext, handler: CallHandler){
        const request = context.switchToHttp().getRequest();
        const organisationId = request.session.organisationId || {};
        
        if (organisationId){
            const organisation = await this.organisationService.findOne(organisationId);
            request.currentOrganisation = organisation;
        }
        return handler.handle();
    }
}
