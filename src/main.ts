import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { ValidationPipe} from "@nestjs/common";
import { SwaggerModule, DocumentBuilder } from "@nestjs/swagger";
const cookieSession = require('cookie-session');

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.use(cookieSession({
      keys: ['secretkey']
  }))
  app.useGlobalPipes(
      new ValidationPipe({
        whitelist: true
      })
  );

  const config = new DocumentBuilder()
      .setTitle('RIV4LZ')
      .setDescription('The cats API description')
      .setVersion('1.0')
      .addTag('cats')
      .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('api', app, document);

  await app.listen(3000);
}
bootstrap();
