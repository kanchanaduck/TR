export interface Trainer {
    id: number;
    emp_no: string;
    readonly name: string;
    readonly type: string;
    readonly status: string;
    update_date: Date;
    update_by: string;
}