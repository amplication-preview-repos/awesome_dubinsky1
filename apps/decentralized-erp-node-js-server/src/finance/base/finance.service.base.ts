/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { PrismaService } from "../../prisma/prisma.service";
import { Prisma, Finance as PrismaFinance } from "@prisma/client";

export class FinanceServiceBase {
  constructor(protected readonly prisma: PrismaService) {}

  async count(args: Omit<Prisma.FinanceCountArgs, "select">): Promise<number> {
    return this.prisma.finance.count(args);
  }

  async finances(args: Prisma.FinanceFindManyArgs): Promise<PrismaFinance[]> {
    return this.prisma.finance.findMany(args);
  }
  async finance(
    args: Prisma.FinanceFindUniqueArgs
  ): Promise<PrismaFinance | null> {
    return this.prisma.finance.findUnique(args);
  }
  async createFinance(args: Prisma.FinanceCreateArgs): Promise<PrismaFinance> {
    return this.prisma.finance.create(args);
  }
  async updateFinance(args: Prisma.FinanceUpdateArgs): Promise<PrismaFinance> {
    return this.prisma.finance.update(args);
  }
  async deleteFinance(args: Prisma.FinanceDeleteArgs): Promise<PrismaFinance> {
    return this.prisma.finance.delete(args);
  }
}