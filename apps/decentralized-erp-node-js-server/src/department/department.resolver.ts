import * as graphql from "@nestjs/graphql";
import { DepartmentResolverBase } from "./base/department.resolver.base";
import { Department } from "./base/Department";
import { DepartmentService } from "./department.service";

@graphql.Resolver(() => Department)
export class DepartmentResolver extends DepartmentResolverBase {
  constructor(protected readonly service: DepartmentService) {
    super(service);
  }
}
