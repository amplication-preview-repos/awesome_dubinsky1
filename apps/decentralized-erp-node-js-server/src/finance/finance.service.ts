import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { FinanceServiceBase } from "./base/finance.service.base";

@Injectable()
export class FinanceService extends FinanceServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
