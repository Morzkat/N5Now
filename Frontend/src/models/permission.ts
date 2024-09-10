import { Employee } from "./employee";
import { PermissionType } from "./permissionType";

export type Permission = {
    id?: number;
    employee: Employee;
    permissionType: PermissionType;
    date?: Date;
}