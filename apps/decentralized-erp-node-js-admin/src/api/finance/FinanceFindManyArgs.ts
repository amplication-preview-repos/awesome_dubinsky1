import { FinanceWhereInput } from "./FinanceWhereInput";
import { FinanceOrderByInput } from "./FinanceOrderByInput";

export type FinanceFindManyArgs = {
  where?: FinanceWhereInput;
  orderBy?: Array<FinanceOrderByInput>;
  skip?: number;
  take?: number;
};
