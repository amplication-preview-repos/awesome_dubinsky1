import { Finance as TFinance } from "../api/finance/Finance";

export const FINANCE_TITLE_FIELD = "id";

export const FinanceTitle = (record: TFinance): string => {
  return record.id?.toString() || String(record.id);
};
