import {
    createParamDecorator,
    ExecutionContext
} from "@nestjs/common";

export const CurrentOrganisation = createParamDecorator(
    (data: never, context: ExecutionContext) => {
        const request = context.switchToHttp().getRequest();

        return request.currentOrganisation;
    }
)
