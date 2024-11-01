import * as graphql from "@nestjs/graphql";
import { FinanceResolverBase } from "./base/finance.resolver.base";
import { Finance } from "./base/Finance";
import { FinanceService } from "./finance.service";

@graphql.Resolver(() => Finance)
export class FinanceResolver extends FinanceResolverBase {
  constructor(protected readonly service: FinanceService) {
    super(service);
  }
}
