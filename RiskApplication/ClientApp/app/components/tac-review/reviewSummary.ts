import { IdType } from './idType';
export class AuditReportSummary {
    public Type: IdType;
    public Expired: number;
    public NoDataSet: number;
    public Pendingin7Days: number;
    public Pendingin30Days: number;
    public Pendingin60Days: number;
    public Pendingin90Days: number;
    public Pendingin120Days: number;
    public Pendingin150Days: number;
    public Pendingin180Days: number;
    public PendinginMoreThan180Days: number;
}
