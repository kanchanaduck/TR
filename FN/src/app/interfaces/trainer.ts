export interface Trainer {
    id: number;
    emp_no: string;
    readonly name: string;
    readonly type: Type;
    readonly status: Status;
    update_date: Date;
    update_by: string;
}


enum Type {
    "Normal",
    "Resigned"
}
enum Status {
    "Internal",
    "External"
}