import {
    createParamDecorator,
    ExecutionContext
} from "@nestjs/common";

export const CurrentCaster = createParamDecorator(
    (data: never, context: ExecutionContext) => {
        const request = context.switchToHttp().getRequest();

        return request.currentCaster;
    },
);
