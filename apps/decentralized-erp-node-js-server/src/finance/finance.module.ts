import { Module } from "@nestjs/common";
import { FinanceModuleBase } from "./base/finance.module.base";
import { FinanceService } from "./finance.service";
import { FinanceController } from "./finance.controller";
import { FinanceResolver } from "./finance.resolver";

@Module({
  imports: [FinanceModuleBase],
  controllers: [FinanceController],
  providers: [FinanceService, FinanceResolver],
  exports: [FinanceService],
})
export class FinanceModule {}
